﻿using DataAccessLayer.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSaha.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comment(int sayfa = 1)
        {
            return View(db.Comments.ToList().ToPagedList(sayfa, 3));
        }
        public ActionResult Delete(int id)
        {
            var delete = db.Comments.Where(x => x.Id == id).FirstOrDefault();
            db.Comments.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Comment");
        }
    }
}