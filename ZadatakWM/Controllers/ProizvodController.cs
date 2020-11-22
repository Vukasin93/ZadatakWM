using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZadatakWM.Models;
using ZadatakWM.Services;

namespace ZadatakWM.Controllers
{
    public class ProizvodController : Controller
    {

        private readonly IDalService _dalService;

        public ProizvodController()
        {
            _dalService = DalServiceFactory.GetDalService();
        }

        public ActionResult Index()
        {
           
            List<Proizvod> listaProizvoda = _dalService.SelectProducts();

             if (listaProizvoda != null)
             {
                
                 return View(listaProizvoda);
             }
             else
             {
                 ViewBag.Greska = "Greska pri citanju podataka";
                 return View();
             }
            
        }

        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {

                string rezultat = _dalService.CreateProudct(proizvod);
                if (rezultat == "true")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Greska = rezultat.ToString();
                }
            }
            return View(proizvod);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Proizvod proizvod = _dalService.SelectProducts().Single(pr => pr.ProizvodId == id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proizvod proizvod)
        {

            if (ModelState.IsValid)
            {

                string rezultat = _dalService.EditProduct(proizvod);
                if (rezultat == "true")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Greska = rezultat;
                }
            }
            return View(proizvod);
        }

       
        [HttpPost]
        public ActionResult Delete(int? id)
        {

            Proizvod proizvod = _dalService.SelectProducts().Single(pr => pr.ProizvodId == id);

            if (proizvod == null)
            {
                return HttpNotFound();
            }

            if (id != null)
            {
               
                _dalService.DeleteProduct((int)id);
            }
            
            return RedirectToAction("Index");
        }


    }
}