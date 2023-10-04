using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IQuanTriVienBusiness
    {
        QuanTriVienModel GetQTVBySDT(string sdt);

        List<QuanTriVienModel> GetAllQuanTriVien();
        bool Create(QuanTriVienModel model);
        bool Update(QuanTriVienModel model);
        bool Delete(string id);


    }
}
