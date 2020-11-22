using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadatakWM.Models;

namespace ZadatakWM.Services
{
    public interface IDalService
    {
        List<Proizvod> SelectProducts();
        string CreateProudct(Proizvod p);
        string EditProduct(Proizvod p);
        string DeleteProduct(int id);
    }
}
