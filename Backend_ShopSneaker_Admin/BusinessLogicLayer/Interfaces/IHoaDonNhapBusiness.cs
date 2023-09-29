using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IHoaDonNhapBusiness
    {
        bool Create(HoaDonNhapModel model);
        //bool Update(HoaDonNhapModel model);

    }
}
