﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Virgil.Models;
using Virgil.Repositories;
using WebGrease.Css.Extensions;

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
            ViewBag.Icons = new SelectList(db.GetIcons(), "icon", "icon");
            topic.DisplayOrder = db.GetNextTopicDisplayOrderValue();
            return View("Create", topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Topic topic, HttpPostedFileBase upload)
        {
            ViewBag.Icons = new SelectList(db.GetIcons(), "icon", "icon");
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
            ViewBag.topicIcons = new SelectList(db.GetIcons(), "icon", "icon");
            ViewBag.Languages = new SelectList(db.GetSupportedLanguages());
            return View("Edit", topic);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Topic topic)
        {
            ViewBag.topicIcons = new SelectList(db.GetIcons(), "icon", "icon");
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

        public ActionResult ManageSections()
        {
            var sections = db.GetSectionsWithEncounters();
            //TODO - Need a new db.GetTopicsWithDisplayOrder() method here, in order to ensure the ManageSections() view honors display order on refresh/postback.
            ViewBag.topics = new SelectList(db.GetTopics(), "id", "Title");
            ViewBag.icons = new SelectList(db.GetIcons(), "icon", "icon");
            return View("ManageSections", sections);
        }

        public JsonResult UpdateTopicsForSection(TopicsForSection t)
        {
            var section = db.GetSectionWithTopicsById(t.SectionId);
            section.Topics.ToList().ForEach(tp => section.Topics.Remove(tp));
            section.SectionTopicOrder = string.Empty;  //empty this to repopulate it
            db.UpdateSection(section);
            foreach (var i in t.Topics)
            {
                var topic = db.GetTopicByName(i);
                section.Topics.Add(topic);
                section.SectionTopicOrder += $",{topic.id}";
            }
            section.SectionTopicOrder = section.SectionTopicOrder.Substring(1);
            try
            {
                db.UpdateSection(section);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json("false");
            }
            var results = section.Topics.Select(topic => new { topic.id, topic.Title }).ToList();
            return Json(results);
        }

        public JsonResult GetTopicsForSection(int id)
        {
            var section = db.GetSectionWithTopicsById(id);

            List<int> selectedVals = new List<int>();
            foreach (var t in section.Topics)
            {
                selectedVals.Add(t.id);
            }
            var topics = db.GetTopics();
            var selectList = new MultiSelectList(topics, "id", "Title", selectedVals);
            return Json(selectList);
        }

        public void UpdateSectionTopicOrder(int id, string topicOrder)
        {
            var section = db.GetSectionById(id);
            section.SectionTopicOrder = topicOrder;
            db.UpdateSection(section);
        }

        public ActionResult Footnotes()
        {
            var model = db.GetFootnotes();
            return View("Footnotes", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Footnotes(Footnotes notes)
        {
            db.UpdateFootnotes(notes);
            return RedirectToAction("Index");
        }
    }
}