using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface ISizeSanPhamRepository
    {
        //SizeSanPhamModel GetSizeSP(string masp);

        bool Create(SizeSanPhamModel model);
        //bool Update(SizeSanPhamModel model);
        //bool Delete(string id);

        
    }
}
