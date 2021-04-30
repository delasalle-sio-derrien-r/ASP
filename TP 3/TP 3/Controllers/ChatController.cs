using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;

namespace TP_3.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> chats;
        public List<Chat> Chats => chats ?? (chats = Chat.GetMeuteDeChats());

        // GET: Chat
        public ActionResult Index()
        {
            return View(Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chat = GetChat(id);
            if (chat != null)
                return View(chat);
            return RedirectToAction("Index");
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = GetChat(id);
            if (chat != null)
            {
                return View(chat);
            }
            return RedirectToAction("Index");
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = GetChat(id);
                if (chat != null)
                {
                    Chats.Remove(chat);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
                
            
        }

        private Chat GetChat(int id)
        {
            return Chats.FirstOrDefault(x => x.Id == id);
        }
    }
}
