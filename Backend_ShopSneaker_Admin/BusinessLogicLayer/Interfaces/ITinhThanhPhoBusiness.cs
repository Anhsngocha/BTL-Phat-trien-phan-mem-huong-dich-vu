using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ITinhThanhPhoBusiness
    {
        
        bool Create(TinhThanhPhoModel model);
        bool Update(TinhThanhPhoModel model);
        bool Delete(string id);

    }
}
