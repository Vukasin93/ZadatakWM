using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ZadatakWM.Models;

namespace ZadatakWM.Services
{
    public class ProizvodJSONDAL : IDalService
    {
        private readonly string _jsonPutanja = string.Empty;
        
        private const string _jsonFileName = "Prodavnica.json";

        private string _baseDirectory = (new FileInfo(AppDomain.CurrentDomain.BaseDirectory)).Directory.FullName;

        private static List<Proizvod> listaProizvoda;

        public ProizvodJSONDAL()
        {
            _jsonPutanja = Path.Combine(_baseDirectory, _jsonFileName);
        }
                
        public List<Proizvod> SelectProducts()
        {
            try
            {
                string desrJson = "";

                using (var reader = new StreamReader(_jsonPutanja))
                {
                    desrJson = reader.ReadToEnd();
                }
                List<Proizvod> proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(desrJson);
                listaProizvoda = proizvodi;
                return proizvodi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string CreateProudct(Proizvod p)
        {
            Proizvod zadnjiProizvod = null;
            if (listaProizvoda.Count > 0)
            {
                zadnjiProizvod = listaProizvoda[listaProizvoda.Count - 1];
            }
            if (zadnjiProizvod != null)
            {
                int zadnjiID = zadnjiProizvod.ProizvodId;
                p.ProizvodId = zadnjiID + 1;
            }


            listaProizvoda.Add(p);
            try
            {
                SerializeJSON();
                return "true";

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }

        public string EditProduct(Proizvod p)
        {
            Proizvod proizvod = listaProizvoda.Single(pr => pr.ProizvodId == p.ProizvodId);

            proizvod.Naziv = p.Naziv;
            proizvod.Opis = p.Opis;
            proizvod.Kategorija = p.Kategorija;
            proizvod.Proizvodjac = p.Proizvodjac;
            proizvod.Dobavljac = p.Dobavljac;
            proizvod.Cena = p.Cena;

            try
            {
                SerializeJSON();
                return "true";

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }


        }

        public string DeleteProduct(int id)
        {
            var zaBrisanje = listaProizvoda.Single(pr => pr.ProizvodId == id);
            listaProizvoda.Remove(zaBrisanje);

            try
            {
                SerializeJSON();
                return "true";


            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }


        public void SerializeJSON()
        {
            var serJson = JsonConvert.SerializeObject(listaProizvoda, Formatting.Indented);
            using (var writer = new StreamWriter(_jsonPutanja))
            {
                writer.WriteLine(serJson);
            }
        }
    }
}