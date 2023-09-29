using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IGiamGiaBusiness
    {

        List<GiamGiaModel> GetAllGiamGia();
        bool Create(GiamGiaModel model);
        bool Update(GiamGiaModel model);
        bool Delete(string id);


    }
}
