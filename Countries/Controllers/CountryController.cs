using Countries.Models;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Countries.Controllers
{
    public class CountryController : Controller
    {
        private readonly Models.Countries _countriesList;

        public CountryController()
        {
            _countriesList = LoadCountries(System.Web.HttpContext.Current.Server.MapPath("~/Content/ListOfCountries.xml"));
        }
        public ActionResult Index()
        {
            return View(_countriesList);
        }

        public static Models.Countries LoadCountries(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Models.Countries), new XmlRootAttribute("Countries"));
            return deserializer.Deserialize(new StreamReader(filePath)) as Models.Countries;
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
                

                return RedirectToAction("Index");
            }
            catch
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
