using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface IChiTietHDRepository
    {
        ChiTietHDModel GetChiTietHDByID(string id);

        List<ChiTietHDModel> GetAllHoaDonBan();
        bool Create(ChiTietHDModel model);
        bool Update(ChiTietHDModel model);
        bool Delete(string id);

        
    }
}
