using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloAspNetMvc.Models;

namespace HelloAspNetMvc.Controllers
{
    public class BoardController : Controller
    {
        private EFDbContext db = new EFDbContext(); // EFDbContext객체를 통해 데이터베이스와 연결

        // Post테이블의 데이터를 조회해 데이터를 포함한 View를 리턴
        // GET: /Board/

        public ActionResult Index() // Action메서드
        {
            return View(db.Posts.ToList()); // View name을 지정하지 않으면 해당 메서드와 같은 이름의 View를 리턴
        }

        //
        // GET: /Board/Details/5

        public ActionResult Details(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Board/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Board/Create

        [HttpPost] // Http 메서드를 POST 방식으로 지정
        [ValidateAntiForgeryToken] // ? 
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.writeTime = DateTime.Now; // 현재시간으로 입력

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        //
        // GET: /Board/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Board/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /Board/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Board/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}