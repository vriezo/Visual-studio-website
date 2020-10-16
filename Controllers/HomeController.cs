using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Database;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
  public class HomeController : Controller
  {
    // zorg ervoor dat je hier je gebruikersnaam (leerlingnummer) en wachtwoord invult
    string connectionString = "Server=172.16.160.21;Port=3306;Database=110189;Uid=110189;Pwd=antHEaNt;";

    public IActionResult Index()
    {
      List<Festival> festivals = GetFestivals();
      return View(festivals);
    } 
    [Route("Show-All")]
    public IActionResult ShowAll()
    {
        return View();
    }
    [Route("Privacy")]
    public IActionResult Privacy()
    {

            return View();
    }

    [Route("Transport")]
    public IActionResult Transport()
    {
      return View();
    }
    [Route("Contact")]
    public IActionResult Contact()
    {
       return View();
    }
    [Route("contact")]
    [HttpPost]
    public IActionResult contact(PersonModel model)
        {
           
            return View(model);
    }
    [Route("Huisregels")]
    public IActionResult Huisregels()
    {
       return View();
    }
    [Route("festivals/{id}")]
    public IActionResult Festivals(string id)
     
        {
            ViewData["festival_id"] = id;
            Festival festival = GetFestival(id);
            return View(festival);
        }

    private Festival GetFestival(string id)
        {
            List<Festival> festivals = new List<Festival>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from festivals where id = " + id + ";", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Festival festival = new Festival
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Naam = reader["Naam"].ToString(),
                            Prijs = Decimal.Parse(reader["prijs"].ToString()),
                            Plaats = reader["Plaats"].ToString(),
                            Beschrijving = reader["Beschrijving"].ToString(),
                            ImgLogo = reader["img-logo"].ToString(),
                            ImgDatabase = reader["Img-database"].ToString(), 
                            Date = DateTime.Parse(reader["datumtijd"].ToString())
                        };
                        festivals.Add(festival);
                    }
                }
            }
            return festivals[0];
        }
    private List<Festival> GetFestivals()
        {
            List<Festival> festivals = new List<Festival>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from festivals", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Festival festival = new Festival
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Naam = reader["Naam"].ToString(),
                            Prijs = Decimal.Parse(reader["prijs"].ToString()),
                            Plaats = reader["Plaats"].ToString(),
                            Beschrijving = reader["Beschrijving"].ToString(),
                            ImgLogo = reader["Img-logo"].ToString(),
                            ImgDatabase = reader["Img-database"].ToString()

                        };
                        festivals.Add(festival);
                    }
                }
            }
            return festivals;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
