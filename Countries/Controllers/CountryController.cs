using System;
using Countries.Models;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Serialization;
using Countries = Countries.Models.Countries;

namespace Countries.Controllers
{
    public class CountryController : Controller
    {
        private readonly Models.Countries _countriesList;

        private readonly string _filePath = 
            System.Web.HttpContext.Current.Server.MapPath("~/Content/ListOfCountries.xml");

        public CountryController()
        {
            _countriesList = Models.Countries.Load(_filePath);
        }
        public ActionResult Index()
        {
            return View(_countriesList);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
               
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            var country = _countriesList.Country.FirstOrDefault(x => x.Id == id);
            return View(country);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            try
            {
                var indexToReplace = _countriesList.FindCountryIndexById(country.Id);
                _countriesList.Country[indexToReplace] = country;
                Models.Countries.Save(_filePath, _countriesList);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
