using System.Linq;
using Kruchy.Uzytkownicy.Services;
using Microsoft.AspNetCore.Mvc;
using ZakupyWebApp.Models;
using ZakupyWebApp.Walidacja;

namespace ZakupyWebApp.Controllers
{
    public class UzytkownicyController : Controller
    {
        private readonly IUzytkownicyService uzytkownicyService;

        public UzytkownicyController(
            IUzytkownicyService uzytkownicyService)
        {
            this.uzytkownicyService = uzytkownicyService;
        }

        public ActionResult Index()
        {
            var model = new ListaUzytkownikowModel();

            model.Uzytkownicy =
                uzytkownicyService
                    .SzukajWszystkich()
                    .Select(o => new UzytkownikRowModel()
                    {
                        ID = o.ID,
                        Nazwa = o.Nazwa,
                        Email = o.Email
                    })
                        .ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new UzytkownikEditModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UzytkownikEditModel form)
        {
            if (ModelState.IsValid)
            {
                if (uzytkownicyService.Dodaj(
                        new DodanieUzytkownikaRequest
                        {
                            Nazwa = form.Nazwa,
                            Email = form.Email,
                            Haslo = form.Haslo,
                            PowtorzenieHasla = form.PowtorzenieHasla
                        },
                        this.DajListeneraWalidacji()) != null)
                    return RedirectToAction("Index");
            }
            return View(form);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var uzytkownik = uzytkownicyService.DajWgID(id);

            var model = new UzytkownikEditModel
            {
                ID = uzytkownik.ID,
                Nazwa = uzytkownik.Nazwa,
                Email = uzytkownik.Email
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UzytkownikEditModel model)
        {
            if (ModelState.IsValid)
            {
                if (uzytkownicyService.Zmien(
                    new ModyfikacjaUzytkownikaRequest
                    {
                        ID = model.ID,
                        Nazwa = model.Nazwa,
                        Haslo = model.Haslo
                    }, this.DajListeneraWalidacji()))
                    return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
