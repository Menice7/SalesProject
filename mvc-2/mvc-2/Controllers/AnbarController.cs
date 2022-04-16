using Microsoft.AspNetCore.Mvc;
using mvc_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace mvc_2.Controllers
{
    public class AnbarController : Controller
    {
        private readonly ILogger<AnbarController> _logger;
        private readonly HttpClient _httpClient;
        public AnbarController(ILogger<AnbarController> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44378/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _logger = logger;
        }
        string CONNECTIONSTRING = "Server = localhost; Database =MainDB; Integrated Security = True;";
        DataTable dataTable = new DataTable();
        
        
        public DataTable GetAnbar()
        {
            DataTable dataTableAnbar = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = "select * from Anbar";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTableAnbar);
            con.Close();
            return dataTableAnbar;
        }
        public DataTable GetAnbar1()
        {
            DataTable dataTableAnbar1 = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = @"select a.ItemId,a.Ad,a.Daxili_Kod,a.Xarici_Kod, 
n.NovAd,o.OlkeAd,a.Say,a.Topdan_Satis_Qiymeti from Nov n, Anbar a,Olke o
  where a.NovId = n.NovId and a.OlkeId = o.OlkeId";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTableAnbar1);
            con.Close();
            return dataTableAnbar1;
        }
        
        public DataTable GetFilial()
        {
            DataTable dataTableFilial = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = "select * from Filial";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTableFilial);
            con.Close();
            return dataTableFilial;
        }

        public List<Anbar> LItems()
        {
            DataTable dataTableAnbar = GetAnbar();
            List<Anbar> items = new List<Anbar>();
            items = (from DataRow dr in dataTableAnbar.Rows
                     select new Anbar()
                     {
                         ItemId = Convert.ToInt32(dr["ItemId"]),
                         Ad = dr["Ad"].ToString(),
                         Daxili_Kod = dr["Daxili_Kod"].ToString(),
                         Xarici_Kod = dr["Xarici_Kod"].ToString(),
                         NovId = Convert.ToInt32(dr["NovId"]),
                         OlkeId = Convert.ToInt32(dr["OlkeId"]),
                         Say = Convert.ToInt32(dr["Say"]),
                         Topdan_Satis_Qiymeti = Convert.ToInt32(dr["Topdan_Satis_Qiymeti"]),
                     }).ToList();
            return items;
        }
        public List<Anbar> LItems1()
        {
            DataTable dataTableAnbar1 = GetAnbar1();
            List<Anbar> items = new List<Anbar>();
            items = (from DataRow dr in dataTableAnbar1.Rows
                     select new Anbar()
                     {
                         ItemId = Convert.ToInt32(dr["ItemId"]),
                         Ad = dr["Ad"].ToString(),
                         Daxili_Kod = dr["Daxili_Kod"].ToString(),
                         Xarici_Kod = dr["Xarici_Kod"].ToString(),
                         NovAd = dr["NovAd"].ToString(),
                         OlkeAd =dr["OlkeAd"].ToString(),
                         Say = Convert.ToInt32(dr["Say"]),
                         Topdan_Satis_Qiymeti = Convert.ToInt32(dr["Topdan_Satis_Qiymeti"]),
                     }).ToList();
            return items;
        }
        #region getfiliallar
        public DataTable GetFiliallar()
        {
            DataTable dataTableFiliallar = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = "select * from Filiallar";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTableFiliallar);
            con.Close();
            return dataTableFiliallar;
        }
        public List<Filiallar> Filiallars()
        {
            DataTable dataTableFiliallar = GetFiliallar();
            List<Filiallar> filiallars = new List<Filiallar>();
            filiallars = (from DataRow dr in dataTableFiliallar.Rows
                          select new Filiallar()
                          {
                              FilialId = Convert.ToInt32(dr["FilialId"]),
                              FilialAd = dr["FilialAd"].ToString()
                          }).ToList();
            return filiallars;
        }
        #endregion

        #region getolke
        public DataTable GetOlke()
        {
            DataTable dataTableOlke = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = "select * from Olke";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTableOlke);
            con.Close();
            return dataTableOlke;
        }
        public List<Olke> LOlkeler()
        {
            DataTable dataTable = GetOlke();
            List<Olke> olkeler = new List<Olke>();
            olkeler = (from DataRow dr in dataTable.Rows
                       select new Olke()
                       {
                           OlkeId = Convert.ToInt32(dr["OlkeId"]),
                           OlkeAd = dr["OlkeAd"].ToString()
                       }).ToList();
            return olkeler;
        }
        #endregion

        #region getnov
        public DataTable GetNov()
        {

            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = "select * from Nov";
            DataTable dataTableNov = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTableNov);
            con.Close();
            return dataTableNov;

        }
        public List<Nov> LNov()
        {
            DataTable dataTable = GetNov();
            List<Nov> novler = new List<Nov>();
            novler = (from DataRow dr in dataTable.Rows
                      select new Nov() {NovId=Convert.ToInt32(dr["NovId"]),
                      NovAd=dr["NovAd"].ToString()}).ToList();
            return novler;
        }
        
        #endregion
        public IActionResult Index()
        {

            List<Anbar> items = LItems1();
            //items listini database-den cekib buradaki items-a menimsetdik
            return View(items);
        }
        #region Item
        public IActionResult CreateItem(int? itemId)
        {
            List<Anbar> items = LItems();
            //items listini database-den cekib buradaki items-a menimsetdik
            #region get
            DataTable dataTableOlke = GetOlke();
            List<Olke> olkeler = new List<Olke>();
            olkeler=(from DataRow dr in dataTableOlke.Rows
    select new Olke() {OlkeId=Convert.ToInt32( dr["OlkeId"]),OlkeAd = dr["OlkeAd"].ToString()}).ToList();
           
            DataTable dataTableNov= GetNov();
            List<Nov> novler = new List<Nov>();
            novler = (from DataRow dr in dataTableNov.Rows 
    select new Nov(){NovId = Convert.ToInt32(dr["NovId"]),NovAd = dr["NovAd"].ToString()}).ToList();
            #endregion
            if (itemId==null){
                Anbar anbar = new Anbar();
                anbar.Olkeler = olkeler;
                anbar.Novler = novler;
                return View(anbar);
            }
            
            else {
                Anbar anbar = items.FirstOrDefault(m => m.ItemId == itemId);
                anbar.Olkeler = olkeler;
                anbar.Novler = novler;
                return View(anbar);
            }
        }
        public IActionResult Create(Anbar anbar)
        {
            List<Anbar> items = LItems();
            //items listini database-den cekib buradaki items-a menimsetdik
            items.Add(anbar);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int itemId)
        {
            
            string CONNECTIONSTRING = "Server = localhost; Database = MainDB; Integrated Security = True;";
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = $"delete from Anbar where ItemId={itemId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
        public IActionResult AddOrUpdate(Anbar anbar)
        {

            if (ModelState.IsValid)
            {
                if (anbar.ItemId == null)
                {
                    
                    SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                    con.Open();
                    string query = $"insert into Anbar values ('{anbar.Ad}','{anbar.Daxili_Kod}'," +
                        $"'{anbar.Xarici_Kod}',{anbar.NovId},{anbar.OlkeId},{anbar.Say}," +
                        $"{anbar.Topdan_Satis_Qiymeti})";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //add
                    //var response = await _httpClient.GetAsync("Anbar/");
                    //response.EnsureSuccessStatusCode();
                    //var content = await response.Content.ReadAsStringAsync();
                    //Anbar anbar1 = JsonConvert.DeserializeObject<Anbar>(content);


                }
                else
                {
                    
                    SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                    con.Open();
                    string query = $"update Anbar set Ad='{anbar.Ad}',Daxili_Kod='{anbar.Daxili_Kod}'," +
                        $"Xarici_Kod='{anbar.Xarici_Kod}',NovId={anbar.NovId}," +
                        $"OlkeId={anbar.OlkeId},Say = {anbar.Say},Topdan_Satis_Qiymeti = {anbar.Topdan_Satis_Qiymeti}" +
                        $" where ItemId = {anbar.ItemId}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //update
                    //var response = await _httpClient.GetAsync("Anbar/" + anbar.ItemId);
                    //response.EnsureSuccessStatusCode();
                    //var content = await response.Content.ReadAsStringAsync();
                    //Anbar anbar1 = JsonConvert.DeserializeObject<Anbar>(content);
                }
                return RedirectToAction("Index");
            }
            else {
                return View("CreateItem",anbar);
            }

            
            
        }
        #endregion

        #region Transfer
        public IActionResult TransferItem(Filial filial)
        {
            DataTable dataTableFiliallar = GetFiliallar();
            List<Filiallar> filiallar = new List<Filiallar>();
            filiallar = (from DataRow dr in dataTableFiliallar.Rows
                       select new Filiallar() { FilialId = Convert.ToInt32(dr["FilialId"]), 
                           FilialAd = dr["FilialAd"].ToString() }).ToList();
         
            filial.Filiallar = filiallar;

            return View(filial);
            
        }
        public IActionResult Transfer(Filial filial)
        {
            

            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = $"insert into Filial values ({filial.ItemId},{filial.FilialId},{filial.Say}) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            string query1 = $"update Anbar set Say = Say - {filial.Say} where ItemId = {filial.ItemId}";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }
        #endregion

        #region Filiallar
        public IActionResult Filiallar()
        {
            List<Filiallar> filiallars = Filiallars();
            return View(filiallars);
        }
        public IActionResult CreateFiliallar(int? filialId)
        {
            List<Filiallar> filiallars = Filiallars();
            //filiallar listini database-den cekib buradaki filiallars-a menimsetdik
            
            if (filialId == null)
            {
                Filiallar filiallar = new Filiallar();
                return View(filiallar);
            }

            else
            {
                Filiallar filiallar = filiallars.FirstOrDefault(m => m.FilialId == filialId);
               
                return View(filiallar);
            }
        
        }
        public IActionResult AddOrUpdateFiliallar(Filiallar filiallar)
        {
            if (ModelState.IsValid)
            {
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                con.Open();
                if (filiallar.FilialId == null)
                {
                    string query = $"insert into Filiallar values ('{filiallar.FilialAd}')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                   
                }
                else
                {
                    string query = $"update Filiallar set FilialAd='{filiallar.FilialAd}' where FilialId={filiallar.FilialId}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    
                }
                con.Close();
                return RedirectToAction("Filiallar");
            }
            else
            {
                return View("CreateFiliallar", filiallar);
            }
        }
        public IActionResult DeleteFiliallar(int? filialId)
        {

            string CONNECTIONSTRING = "Server = localhost; Database = MainDB; Integrated Security = True;";
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = $"delete from Filiallar where FilialId={filialId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Filiallar");
        }

        #endregion

        #region Olkeler
        public IActionResult Olkeler()
        {
            List<Olke> olkeler = LOlkeler();
            return View(olkeler);
        }
        public IActionResult CreateOlke(int? olkeId)
        {
            List<Olke> olkelers = LOlkeler();
            if (olkeId == null)
            {
                Olke olke = new Olke();
                return View(olke);
            }
            else
            {
                Olke olke = olkelers.FirstOrDefault(m => m.OlkeId==olkeId);
                return View(olke);
            }
        }
        public IActionResult AddOrUpdateOlke(Olke olke) 
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            if (ModelState.IsValid)
            {
                if (olke.OlkeId == null)
                {

                    string query = $"insert into Olke values ('{olke.OlkeAd}')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    string query = $"update Olke set OlkeAd='{olke.OlkeAd}' where OlkeId={olke.OlkeId}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                return RedirectToAction("Olkeler");
                
            }
            else
            {
                return View("CreateOlke", olke);
            }
            
        }
        public IActionResult DeleteOlke(int? olkeId)
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = $"delete from Olke where OlkeId={olkeId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Olkeler");
        }
        #endregion

        #region Novler
        public IActionResult Novler()
        {
            List<Nov> novler = LNov();
            return View(novler);
        }
        public IActionResult CreateNov(int? novId)
        {
            List<Nov> novler = LNov();
            if (novId == null)
            {
                Nov nov = new Nov();
                return View(nov);
            }
            else
            {
                Nov nov = novler.FirstOrDefault(m => m.NovId == novId);
                return View(nov);
            }
        }
        public IActionResult AddOrUpdateNov(Nov nov)
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            if (ModelState.IsValid)
            {
                if (nov.NovId == null)
                {

                    string query = $"insert into Nov values ('{nov.NovAd}')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    string query = $"update Nov set NovAd='{nov.NovAd}' where NovId={nov.NovId}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                return RedirectToAction("Novler");

            }
            else
            {
                return View("CreateNov", nov);
            }

        }
        public IActionResult DeleteNov(int? novId)
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = $"delete from Nov where NovId={novId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Novler");
        }
        #endregion

        #region Export
       

        public ActionResult Export()
        {
            List<Anbar> litems1 = LItems1();
            return View(litems1);
        }

        public ActionResult GetData()
        {
            List<Anbar> litems1 = LItems1();
            return View(litems1);
        }
        #endregion
        #region Hesabat


        public ActionResult Hesabatlar()
        {

            List<Anbar> litems1 = LItems1();
            return View(litems1);
        }


        #endregion

        #region Login
        public List<Isciler> LIsciler()
        {
            DataTable dataTableIsciler = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            con.Open();
            string query = @"select * from Isciler 
                           ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTableIsciler);
            con.Close();

            List<Isciler> isciler = new List<Isciler>();
            isciler = (from DataRow dr in dataTableIsciler.Rows
                       select new Isciler()
                       {
                           Id = Convert.ToInt32(dr["IsciId"]),
                           Name = dr["Name"].ToString(),
                           SurName = dr["SurName"].ToString(),
                           GMail = dr["EMail"].ToString(),
                           UserName = dr["UserName"].ToString(),
                           Password = dr["Password"].ToString(),
                           RoleId =Convert.ToInt32( dr["RoleId"]),
                           TrueFalse = true
                       }).ToList();
      
            return isciler;
        }
        public IActionResult Login1()
        {

            return View("Login");

        }
        public IActionResult Login(Isciler isciler)
        {
            List<Isciler> lisciler = LIsciler();
            List<Anbar> items = LItems1();

            string str = "";

            foreach (var i in lisciler)
            {


                if (isciler.UserName == i.UserName.Trim() & isciler.Password == i.Password.Trim())
                {
                    if (i.RoleId == 1)
                    {
                        str = "Index";
                        return View(str, items);
                    }
                    else if (i.RoleId == 2)
                    {
                        str = "Index";
                     
                        return View(str, items);

                    }
                    else { RedirectToAction("Index"); }
                }
            }
            return View(str, items);
        }

        public IActionResult Registration()
        {
            return View();
        }
        //public IActionResult UserToAddDB()
        //{
        //    SqlConnection con = new SqlConnection(CONNECTIONSTRING);
        //    con.Open();
        //    string query = $"insert into User1 values ('{user.Username}','{user.Ad}'," +
        //        $"'{user.Soyad}','{user.Sifre}','{user.Email}',{user.RoleId})";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return View("Login");
        //}
        #endregion



    }
}
