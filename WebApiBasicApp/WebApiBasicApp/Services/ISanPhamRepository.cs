using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBasicApp.ViewModel;

namespace WebApiBasicApp.Services
{
    public interface ISanPhamRepository
    {
        List<SanPhamVM> GetAll();
        SanPhamVM GetById(Guid id);
        SanPhamVM Add(SanPhamModel sp);
        void Update(SanPhamVM sp);
        void Delete(Guid id);
    }
}
