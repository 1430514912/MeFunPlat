using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFunModel;
namespace UI.Areas.Partitions.Controllers
{
    public class RegionalManagementController : Controller
    {
        // GET: Partitions/RegionalManagement
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            List<Area> poplist = new List<Area>();
            using (MyContext db = new MyContext())
            {
                poplist = db.Area.Where(x => x.ARState == 0).ToList();
            }
            var data = new
            {
                count = poplist.Count(),//数据总条数，用于分页
                code = 0,//code码是必须要的， 0 表述返回的数据没有问题
                data = poplist,//数据源
                msg = "权限信息"//描述
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Addf()
        {
            return View();
        }
        public ActionResult AddDaq(Area info)
        {
            string result = "Fail";
            using (MyContext db = new MyContext())
            {
                info.ARParent = -1;
                info.ARIndex = db.Area.Where(x => x.ARParent == -1).Count();
                db.Area.Add(info);
                int r = db.SaveChanges();
                if (r > 0)
                {
                    result = "Success";
                }
            }
            return Content(result);
        }
        public ActionResult AddZ()
        {
            return View();
        }
        public ActionResult DelAnnouncer(Area info)
        {
            string result = "Fail";
            using (MyContext db = new MyContext())
            {
                Area aninfo = db.Area.Where(x => x.ARID == info.ARID).FirstOrDefault();
                db.Area.Remove(aninfo);
                int r = db.SaveChanges();
                if (r > 0)
                {
                    result = "Success";
                }
            }
            return Content(result);
        }
        public JsonResult GetCity()
        {
            List<Area> poplist = new List<Area>();
            using (MyContext db = new MyContext())
            {
                poplist = db.Area.Where(x => x.ARState == 0).ToList();
            }
            return Json(poplist);
        }
    }
}