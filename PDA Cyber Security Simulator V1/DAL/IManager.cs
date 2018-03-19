using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1.DAL
{
    public interface IManager<T> where T : class
    {
        T GetItem();
        void AddItem(T newItem);
        void DeleteItem(int id);
        void UpdateItem(int id, T updatedItem);
    }
}
