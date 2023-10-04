using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface IPhiVanChuyenRepository
    {
      
        bool Create(PhiVanChuyenModel model);
        bool Update(PhiVanChuyenModel model);
        bool Delete(string id);

    }
}
