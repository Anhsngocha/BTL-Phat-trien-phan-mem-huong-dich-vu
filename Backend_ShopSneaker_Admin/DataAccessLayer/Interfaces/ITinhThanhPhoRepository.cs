using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface ITinhThanhPhoRepository
    {
      
        bool Create(TinhThanhPhoModel model);
        bool Update(TinhThanhPhoModel model);
        bool Delete(string id);

    }
}
