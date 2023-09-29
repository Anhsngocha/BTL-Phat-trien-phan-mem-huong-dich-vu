using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface IGiamGiaRepository
    {
        
        List<GiamGiaModel> GetAllGiamGia();
        bool Create(GiamGiaModel model);
        bool Update(GiamGiaModel model);
        bool Delete(string id);

    }
}
