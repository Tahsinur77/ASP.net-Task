using news_task.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace news_task.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(News n)
        {
            if (ModelState.IsValid)
            {
                News_taskEntities db = new News_taskEntities();
                db.News.Add(n);
                db.SaveChanges();
                return RedirectToAction("Show");
            }
            return View(n);
        }
        [HttpGet]
        public ActionResult Show()
        {
            News_taskEntities db = new News_taskEntities();
            var newsList = db.News.ToList();
            return View(newsList);
        }

        [HttpPost]
        public ActionResult Show(string category,string date)
        {
      
            if (date == "")
            {
                News_taskEntities db = new News_taskEntities();
                var byCategory = (from x in db.News
                                  where x.Category.Equals(category)
                                  select x).ToList();
                return View(byCategory);
            }
            else if(category == "")
            {
                DateTime oDate = Convert.ToDateTime(date);
                News_taskEntities db = new News_taskEntities();
                var byDate = (from x in db.News
                                  where x.PublishDate.Equals(oDate)
                                  select x).ToList();
                return View(byDate);
            }
            else if (category != "" && date != "")
            {
                DateTime oDate = Convert.ToDateTime(date);
                News_taskEntities db = new News_taskEntities();
                var byDate = (from x in db.News
                              where x.PublishDate.Equals(oDate)
                              && x.Category.Equals(category)
                              select x).ToList();
                return View(byDate);
            }
            else
            {
                return RedirectToAction("Show");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            News_taskEntities db = new News_taskEntities();
            var news = (from n in db.News
                        where n.Id.Equals(id)
                        select n).FirstOrDefault();
            return View(news);
        }

        [HttpPost]
        public ActionResult Edit(News n)
        {
            if (ModelState.IsValid)
            {
                News_taskEntities db = new News_taskEntities();
                var old = (from b in db.News
                            where b.Id.Equals(n.Id)
                            select b).FirstOrDefault();
                db.Entry(old).CurrentValues.SetValues(n);
                db.SaveChanges();
                return RedirectToAction("Show");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            News_taskEntities db = new News_taskEntities();
            var obj = (from n in db.News
                        where n.Id.Equals(id)
                        select n).FirstOrDefault();
            db.News.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Show");
        }
       
        
    }
}