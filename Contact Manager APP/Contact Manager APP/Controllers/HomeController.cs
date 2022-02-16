using Contact_Manager_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager_APP.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts.Include(c => c.Category).OrderBy(context => context.FirstName).ToList();
            return View(contacts);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactID == id);
            return View(contact);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

            return View("Edit", new Contact());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactID == id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            string action = (contact.ContactID == 0) ? "Add" : "Edit";

            if(ModelState.IsValid)
            {
                if(action == "Add")
                {
                    contact.DateAdded = DateTime.Now;
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Contacts.Update(contact);
                }
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
                return View(contact);
            }
        }
   
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Include(c => c.ContactID == id).FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();

            return View("Index", "Home");
        }
      
    }
}
