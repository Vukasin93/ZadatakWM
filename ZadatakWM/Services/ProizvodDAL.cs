using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZadatakWM.Models;

namespace ZadatakWM.Services
{
    public class ProizvodDAL : IDalService
    {

        public List<Proizvod> SelectProducts()
        {
            List<Proizvod> listaProizvoda = new List<Proizvod>();

            string upit = "SELECT * FROM Proizvod";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.KonekcioniString()))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        konekcija.Open();
                        SqlDataReader dr = komanda.ExecuteReader();
                        while (dr.Read())
                        {
                            Proizvod p1 = new Proizvod
                            {
                                ProizvodId = int.Parse(dr["ProizvodId"].ToString()),
                                Naziv = dr["Naziv"].ToString(),
                                Opis = dr["Opis"].ToString(),
                                Kategorija = dr["Kategorija"].ToString(),
                                Proizvodjac = dr["Proizvodjac"].ToString(),
                                Dobavljac = dr["Dobavljac"].ToString(),
                                Cena = double.Parse(dr["Cena"].ToString())
                               
                            };
                            listaProizvoda.Add(p1);
                        }
                        return listaProizvoda;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }
        
        public string CreateProudct(Proizvod p)
        {
            string upit = @"INSERT INTO Proizvod VALUES (@Naziv, @Opis, @Kategorija, @Dobavljac, @Proizvodjac, @Cena)";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.KonekcioniString()))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@Naziv", p.Naziv);
                        komanda.Parameters.AddWithValue("@Opis", p.Opis);
                        komanda.Parameters.AddWithValue("@Kategorija", p.Kategorija);
                        komanda.Parameters.AddWithValue("@Dobavljac", p.Dobavljac);
                        komanda.Parameters.AddWithValue("@Proizvodjac", p.Proizvodjac);
                        komanda.Parameters.AddWithValue("@Cena", p.Cena);
                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        return "true";
                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }
                }
            }
        }

        public string EditProduct(Proizvod p)
        {
            string upit = @"UPDATE Proizvod SET Naziv = @Naziv, Opis = @Opis, Kategorija = @Kategorija, Proizvodjac = @Proizvodjac,Dobavljac = @Dobavljac, Cena = @Cena WHERE ProizvodId = @ProizvodId";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.KonekcioniString()))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@ProizvodId", p.ProizvodId);
                        komanda.Parameters.AddWithValue("@Naziv", p.Naziv);
                        komanda.Parameters.AddWithValue("@Opis", p.Opis);
                        komanda.Parameters.AddWithValue("@Kategorija", p.Kategorija);
                        komanda.Parameters.AddWithValue("@Proizvodjac", p.Proizvodjac);
                        komanda.Parameters.AddWithValue("@Dobavljac", p.Dobavljac);
                        komanda.Parameters.AddWithValue("@Cena", p.Cena);
                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        return "true";
                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }
                }
            }
        }

        public string DeleteProduct(int id)
        {
            string upit = "DELETE FROM Proizvod WHERE ProizvodId = @ProizvodId";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.KonekcioniString()))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("ProizvodId", id);
                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        return "true";
                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }
                }
            }
        }

    }
}