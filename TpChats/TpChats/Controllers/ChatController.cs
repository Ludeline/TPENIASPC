using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpChats.DB;
using TpChats.Models;

namespace TpChats.Controllers
{
    public class ChatController : Controller
    {
        
        // GET: Chat
        public ActionResult Index()
        {
            return View(BDD.Instance.ListeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chats = BDD.Instance.ListeChats.FirstOrDefault(c => c.Id == id);
            return View(chats);
        }


        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Chat chats = BDD.Instance.ListeChats.FirstOrDefault(c => c.Id == id);
            return View(chats);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chats = BDD.Instance.ListeChats.FirstOrDefault(c => c.Id == id);
                BDD.Instance.ListeChats.Remove(chats);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
