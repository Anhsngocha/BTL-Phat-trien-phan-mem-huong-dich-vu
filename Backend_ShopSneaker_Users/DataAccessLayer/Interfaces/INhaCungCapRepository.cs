using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface INhaCungCapRepository
    {
        NhaCungCapModel GetNhaCungCapByID(string id);
        List<NhaCungCapModel> GetAllNhaCungCap();
        bool Create(NhaCungCapModel model);
        bool Update(NhaCungCapModel model);
        bool Delete(string id);

    }
}
