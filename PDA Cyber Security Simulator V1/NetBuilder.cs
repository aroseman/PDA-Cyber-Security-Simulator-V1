﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class NetBuilder : Form
    {
        #region "DragVariables"
        public bool Status { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public bool isDragged = false;
        Point ptOffset;
        #endregion //DragVariables


        // The "size" of an object for mouse over purposes.
        private const int object_radius = 3;

        // We're over an object if the distance squared
        // between the mouse and the object is less than this.
        private const int over_dist_squared = object_radius * object_radius;

        // The points that make up the line segments.
        private List<Point> Pt1 = new List<Point>();
        private List<Point> Pt2 = new List<Point>();

        // Points for the new line.
        private bool IsDrawing = false;
        private Point NewPt1, NewPt2;

        //variable to enable line drawing
        //DRAWING ALSO DISABLES DRAG AND DROP
        private bool drawable = false;
        private Network network;
        //public Device Device { get; set; }
        private Object activeObject;
        
        public NetBuilder()
        {
            
            InitializeComponent();
            network = new Network();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeDragDrop();
            InitializePopup();
            lblDrawEnabled.Visible = false;
        }

        // The mouse is up. See whether we're over an end point or segment.
        private void canvas_MouseMove_NotDown(object sender, MouseEventArgs e)
        {
            Cursor new_cursor = Cursors.Cross;

            // See what we're over.
            Point hit_point;
            int segment_number;

            if (MouseIsOverEndpoint(e.Location, out segment_number, out hit_point))
                new_cursor = Cursors.Arrow;
            else if (MouseIsOverSegment(e.Location, out segment_number))
                new_cursor = Cursors.Hand;

            // Set the new cursor.
            if (canvas.Cursor != new_cursor)
                canvas.Cursor = new_cursor;
        }

        // See what we're over and start doing whatever is appropriate.
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawable)
            {
                // See what we're over.
                Point hit_point;
                int segment_number;

                if (MouseIsOverEndpoint(e.Location, out segment_number, out hit_point))
                {
                    // Start moving this end point.
                    canvas.MouseMove -= canvas_MouseMove_NotDown;
                    canvas.MouseMove += canvas_MouseMove_MovingEndPoint;
                    canvas.MouseUp += canvas_MouseUp_MovingEndPoint;

                    // Remember the segment number.
                    MovingSegment = segment_number;

                    // See if we're moving the start end point.
                    MovingStartEndPoint = (Pt1[segment_number].Equals(hit_point));

                    // Remember the offset from the mouse to the point.
                    OffsetX = hit_point.X - e.X;
                    OffsetY = hit_point.Y - e.Y;
                }
                else if (MouseIsOverSegment(e.Location, out segment_number))
                {
                    // Start moving this segment.
                    canvas.MouseMove -= canvas_MouseMove_NotDown;
                    canvas.MouseMove += canvas_MouseMove_MovingSegment;
                    canvas.MouseUp += canvas_MouseUp_MovingSegment;

                    // Remember the segment number.
                    MovingSegment = segment_number;

                    // Remember the offset from the mouse to the segment's first point.
                    OffsetX = Pt1[segment_number].X - e.X;
                    OffsetY = Pt1[segment_number].Y - e.Y;
                }
                else
                {
                    // Start drawing a new segment.
                    canvas.MouseMove -= canvas_MouseMove_NotDown;
                    canvas.MouseMove += canvas_MouseMove_Drawing;
                    canvas.MouseUp += canvas_MouseUp_Drawing;

                    IsDrawing = true;
                    NewPt1 = new Point(e.X, e.Y);
                    NewPt2 = new Point(e.X, e.Y);
                }
            }
        }

        #region "Drawing"

        // We're drawing a new segment.
        private void canvas_MouseMove_Drawing(object sender, MouseEventArgs e)
        {
            // Save the new point.
            NewPt2 = new Point(e.X, e.Y);

            // Redraw.
            canvas.Invalidate();
        }

        // Stop drawing.
        private void canvas_MouseUp_Drawing(object sender, MouseEventArgs e)
        {
            IsDrawing = false;

            // Reset the event handlers.
            canvas.MouseMove -= canvas_MouseMove_Drawing;
            canvas.MouseMove += canvas_MouseMove_NotDown;
            canvas.MouseUp -= canvas_MouseUp_Drawing;

            // Create the new segment.
            Pt1.Add(NewPt1);
            Pt2.Add(NewPt2);

            // Redraw.
            canvas.Invalidate();
        }

        #endregion // Drawing

        #region "Moving End Point"

        // The segment we're moving or the segment whose end point we're moving.
        private int MovingSegment = -1;

        // The end point we're moving.
        private bool MovingStartEndPoint = false;

        // The offset from the mouse to the object being moved.
        private int OffsetX, OffsetY;

        // We're moving an end point.
        private void canvas_MouseMove_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Move the point to its new location.
            if (MovingStartEndPoint)
                Pt1[MovingSegment] =
                    new Point(e.X + OffsetX, e.Y + OffsetY);
            else
                Pt2[MovingSegment] =
                    new Point(e.X + OffsetX, e.Y + OffsetY);

            // Redraw.
            canvas.Invalidate();
        }

        // Stop moving the end point.
        private void canvas_MouseUp_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            canvas.MouseMove += canvas_MouseMove_NotDown;
            canvas.MouseMove -= canvas_MouseMove_MovingEndPoint;
            canvas.MouseUp -= canvas_MouseUp_MovingEndPoint;

            // Redraw.
            canvas.Invalidate();
        }

        #endregion // Moving End Point

        #region "Moving Segment"

        // We're moving a segment.
        private void canvas_MouseMove_MovingSegment(object sender, MouseEventArgs e)
        {
            // See how far the first point will move.
            int new_x1 = e.X + OffsetX;
            int new_y1 = e.Y + OffsetY;

            int dx = new_x1 - Pt1[MovingSegment].X;
            int dy = new_y1 - Pt1[MovingSegment].Y;

            if (dx == 0 && dy == 0) return;

            // Move the segment to its new location.
            Pt1[MovingSegment] = new Point(new_x1, new_y1);
            Pt2[MovingSegment] = new Point(
                Pt2[MovingSegment].X + dx,
                Pt2[MovingSegment].Y + dy);

            // Redraw.
            canvas.Invalidate();
        }

        // Stop moving the segment.
        private void canvas_MouseUp_MovingSegment(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            canvas.MouseMove += canvas_MouseMove_NotDown;
            canvas.MouseMove -= canvas_MouseMove_MovingSegment;
            canvas.MouseUp -= canvas_MouseUp_MovingSegment;

            // Redraw.
            canvas.Invalidate();
        }

        #endregion // Moving End Point

        // See if the mouse is over an end point.
        private bool MouseIsOverEndpoint(Point mouse_pt, out int segment_number, out Point hit_pt)
        {
            for (int i = 0; i < Pt1.Count; i++)
            {
                // Check the starting point.
                if (FindDistanceToPointSquared(mouse_pt, Pt1[i]) < over_dist_squared)
                {
                    // We're over this point.
                    segment_number = i;
                    hit_pt = Pt1[i];
                    return true;
                }

                // Check the end point.
                if (FindDistanceToPointSquared(mouse_pt, Pt2[i]) < over_dist_squared)
                {
                    // We're over this point.
                    segment_number = i;
                    hit_pt = Pt2[i];
                    return true;
                }
            }

            segment_number = -1;
            hit_pt = new Point(-1, -1);
            return false;
        }

        // See if the mouse is over a line segment.
        private bool MouseIsOverSegment(Point mouse_pt, out int segment_number)
        {
            for (int i = 0; i < Pt1.Count; i++)
            {
                // See if we're over the segment.
                PointF closest;
                if (FindDistanceToSegmentSquared(
                    mouse_pt, Pt1[i], Pt2[i], out closest)
                        < over_dist_squared)
                {
                    // We're over this segment.
                    segment_number = i;
                    return true;
                }
            }

            segment_number = -1;
            return false;
        }

        // Calculate the distance squared between two points.
        private int FindDistanceToPointSquared(Point pt1, Point pt2)
        {
            int dx = pt1.X - pt2.X;
            int dy = pt1.Y - pt2.Y;
            return dx * dx + dy * dy;
        }

        // Calculate the distance squared between
        // point pt and the segment p1 --> p2.
        private double FindDistanceToSegmentSquared(Point pt, Point p1, Point p2, out PointF closest)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return dx * dx + dy * dy;
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return dx * dx + dy * dy;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Draw the segments.
            for (int i = 0; i < Pt1.Count; i++)
            {
                // Draw the segment.
                e.Graphics.DrawLine(Pens.Blue, Pt1[i], Pt2[i]);
            }

            // Draw the end points.
            foreach (Point pt in Pt1)
            {
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }
            foreach (Point pt in Pt2)
            {
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }

            // If there's a new segment under constructions, draw it.
            if (IsDrawing)
            {
                e.Graphics.DrawLine(Pens.Red, NewPt1, NewPt2);
            }
        }

       
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
        
            base.OnFormClosing(e);
            System.Windows.Forms.Application.Exit(); // Do not move!
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

           // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:

                    break;
            }
        }

        #region "DragDrop"
        private void InitializeDragDrop()
        {
            canvas.AllowDrop = true;
            canvas.DragEnter += panel_DragEnter;
            canvas.DragDrop += panel_DragDrop;

            pictureBox1.MouseDown += pictureBox_MouseDown;
            pictureBox2.MouseDown += pictureBox_MouseDown;
            pictureBox3.MouseDown += pictureBox_MouseDown;
            pictureBox4.MouseDown += pictureBox_MouseDown;
            pictureBox5.MouseDown += pictureBox_MouseDown;
            pictureBox6.MouseDown += pictureBox_MouseDown;
            pictureBox7.MouseDown += pictureBox_MouseDown;
            pictureBox8.MouseDown += pictureBox_MouseDown;
            pictureBox9.MouseDown += pictureBox_MouseDown;
            pictureBox10.MouseDown += pictureBox_MouseDown;
            pictureBox11.MouseDown += pictureBox_MouseDown;
            pictureBox12.MouseDown += pictureBox_MouseDown;
            pictureBox13.MouseDown += pictureBox_MouseDown;
            pictureBox14.MouseDown += pictureBox_MouseDown;

            pictureBox1.MouseUp += pictureBox_MouseUp;
            pictureBox2.MouseUp += pictureBox_MouseUp;
            pictureBox3.MouseUp += pictureBox_MouseUp;
            pictureBox4.MouseUp += pictureBox_MouseUp;
            pictureBox5.MouseUp += pictureBox_MouseUp;
            pictureBox6.MouseUp += pictureBox_MouseUp;
            pictureBox7.MouseUp += pictureBox_MouseUp;
            pictureBox8.MouseUp += pictureBox_MouseUp;
            pictureBox9.MouseUp += pictureBox_MouseUp;
            pictureBox10.MouseUp += pictureBox_MouseUp;
            pictureBox11.MouseUp += pictureBox_MouseUp;
            pictureBox12.MouseUp += pictureBox_MouseUp;
            pictureBox13.MouseUp += pictureBox_MouseUp;
            pictureBox14.MouseUp += pictureBox_MouseUp;

            pictureBox1.MouseMove += pictureBox_MouseMove;
            pictureBox2.MouseMove += pictureBox_MouseMove;
            pictureBox3.MouseMove += pictureBox_MouseMove;
            pictureBox4.MouseMove += pictureBox_MouseMove;
            pictureBox5.MouseMove += pictureBox_MouseMove;
            pictureBox6.MouseMove += pictureBox_MouseMove;
            pictureBox7.MouseMove += pictureBox_MouseMove;
            pictureBox8.MouseMove += pictureBox_MouseMove;
            pictureBox9.MouseMove += pictureBox_MouseMove;
            pictureBox10.MouseMove += pictureBox_MouseMove;
            pictureBox11.MouseMove += pictureBox_MouseMove;
            pictureBox12.MouseMove += pictureBox_MouseMove;
            pictureBox13.MouseMove += pictureBox_MouseMove;
            pictureBox14.MouseMove += pictureBox_MouseMove;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawable == false)
            {
                //Check to see if the parent is the canvas
                if (((PictureBox)sender).Parent == canvas)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isDragged = true;
                        //grab the current location of the picture box
                        Point ptStartPosition = ((PictureBox)sender).PointToScreen(new Point(e.X, e.Y));

                        ptOffset = new Point();
                        ptOffset.X = ((PictureBox)sender).Location.X - ptStartPosition.X;
                        ptOffset.Y = ((PictureBox)sender).Location.Y - ptStartPosition.Y;
                    }
                    else
                    {
                        isDragged = false;
                    }
                }
                //Drag and drop onto the canvas
                else
                {
                    ((PictureBox)sender).DoDragDrop(((PictureBox)sender), DragDropEffects.Move);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //Stop dragging
            isDragged = false;
            if(((PictureBox)sender).Location.X >= picTrashCan.Location.X - 30 && ((PictureBox)sender).Location.Y >= picTrashCan.Location.Y && ((PictureBox)sender).Location.X <= picTrashCan.Location.X + 60 && ((PictureBox)sender).Location.Y <= picTrashCan.Location.Y + 80)
            {
                ((PictureBox)sender).Parent = flowLayoutPanel1;
            }
            //This is to check to see if the picture is out of bounds
            //If it is, reset its location
            if (((PictureBox)sender).Location.X < 0 || ((PictureBox)sender).Location.Y < 0 || ((PictureBox)sender).Location.X > 750 || ((PictureBox)sender).Location.Y > 700)
            {
                ((PictureBox)sender).Location = new Point(0, 0);
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged)
            {   
                //Grab the point of the cursor on the screen
                Point newPoint = ((PictureBox)sender).PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(ptOffset);

                //Update the location of the object
                ((PictureBox)sender).Location = newPoint;
            }
        }

        //Setup for the drop onto the canvas
        void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        //Update the parent of the object
        void panel_DragDrop(object sender, DragEventArgs e)
        {
            var device = new Device();
            ((PictureBox)e.Data.GetData(typeof(PictureBox))).Parent = (Panel)sender;
            ((PictureBox)e.Data.GetData(typeof(PictureBox))).BringToFront();
            ((PictureBox)e.Data.GetData(typeof(PictureBox))).Tag = device;
        }

        #endregion //DragDrop

        private void enableLineDraw_MouseClick(object sender, MouseEventArgs e)
        {
            //toggle the draw command
            drawable = !drawable;
            lblDrawEnabled.Visible = drawable ? true : false;
        }

        #region "DevicePopup"
        private void InitializePopup()
        {
            pictureBox1.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox2.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox3.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox4.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox5.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox6.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox7.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox8.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox9.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox10.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox11.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox12.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox13.MouseDoubleClick += pictureBox_MouseDoubleClick;
            pictureBox14.MouseDoubleClick += pictureBox_MouseDoubleClick;
        }

        //Double click handler to display the popup box with device properties
        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(((PictureBox)sender).Parent == canvas)
            {
                //Trigger the popup to show
                DeviceProperties devicePropertiesPopup = new DeviceProperties((Device)((PictureBox)sender).Tag);
                DialogResult dialogResult = devicePropertiesPopup.ShowDialog();
                

                //Result handlers
                if(dialogResult == DialogResult.OK)
                {
                    network.Devices.Add(devicePropertiesPopup.Device);
                    ((PictureBox)sender).Tag = devicePropertiesPopup.Device;
                    devicePropertiesPopup.Dispose();
                }
                else if(dialogResult == DialogResult.Cancel)
                {
                    devicePropertiesPopup.Dispose();
                }
            }
        }
        #endregion
    }
}
