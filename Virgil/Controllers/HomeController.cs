using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Virgil.Models;
using Virgil.Repositories;

namespace Virgil.Controllers
{
    public class HomeController : Controller
    {
        private readonly TopicsRepository db = new TopicsRepository();
        [Authorize]
        public ActionResult Index()
        {
            var topics = db.GetTopics();
            ViewBag.Languages = new SelectList(db.GetSupportedLanguages());
            return View("Index", topics);
        }

        public ActionResult Create()
        {
            var topic = new Topic();
            ViewBag.Languages = new SelectList(db.GetSupportedLanguages());
            topic.DisplayOrder = db.GetNextTopicDisplayOrderValue();
            return View("Create", topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Topic topic, HttpPostedFileBase upload)
        {
            db.AddTopic(topic);
            if (upload != null && upload.ContentLength > 0)
            {
                var file = new Medium
                {
                    FileName = Path.Combine(Server.MapPath("~/Media/Images"), upload.FileName),
                    ContentType = upload.ContentType,
                    Title = upload.FileName,
                    Tip = ""
                };

                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    file.Content = reader.ReadBytes(upload.ContentLength);
                }
                db.AddMedia(file, topic);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var topic = db.GetTopicById(id);
            ViewBag.Languages = new SelectList(db.GetSupportedLanguages());
            return View("Edit", topic);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Topic topic)
        {
            db.UpdateTopic(topic);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var topic = db.GetTopicById(id);
            return View("Delete", topic);
        }

        [HttpPost]
        public ActionResult Delete(Topic topic)
        {
            db.RemoveTopic(topic);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Media/Images"), pic);
                // file is uploaded
                file.SaveAs(path);
                
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Create", "Home");
        }
    }
}