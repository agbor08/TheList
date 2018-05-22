using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista.Services
{
    public interface IListService
    {
        void AddToFile(string listItem);
        IEnumerable<string> ReadListFromFile();
        void ClearListFile();
    }
}
