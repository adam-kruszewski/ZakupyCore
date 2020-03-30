using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZakupyWebApp.Models;

namespace ZakupyWebApp.Controllers
{
    public class UzytkownicyController : Controller
    {


        public ActionResult Index()
        {
            var model = new ListaUzytkownikowModel();

            model.Uzytkownicy = new[]
            { 
                new UzytkownikRowModel()
                {
                    Nazwa = "Adam",
                    Email = "adam@adam.pl",
                    ID = 1983
                }
            }
                    .ToList();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new UzytkownikEditModel
            {
                ID = 1983,
                Nazwa = "adam",
                Email = "adam@adam.pl"
            };

            return View(model);
        }
    }
}
