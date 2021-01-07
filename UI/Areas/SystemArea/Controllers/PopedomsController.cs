using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFunModel;

namespace UI.Areas.SystemArea.Controllers
{
    public class PopedomsController : Controller
    {
        // GET: SystemArea/Popedoms
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            List<SysPopedoms> poplist = new List<SysPopedoms>();
            using (MyContext db = new MyContext())
            {
                poplist = db.SysPopedoms.Where(x=>x.PopState == 1).ToList();
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
    }
}