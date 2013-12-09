using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Service.DTO;
using Service.Handler;

namespace Website.Controllers
{
    public class ComponentRightPanelController : Controller
    {
        //
        // GET: /ComponentRightPanel/

        CategoryHandler _category = new CategoryHandler();

        private static ProductHandler _productHandler = new ProductHandler();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OnlineContact()
        {
            return PartialView();
        }

        public ActionResult AboutUs()
        {
            return PartialView();
        }

        public ActionResult ProductNewest()
        {
            List<ProductOverviewDto> newestProduct = ProductHandler.getNewestProduct();
            return PartialView(newestProduct);
        }

        public ActionResult Search()
        {
            return PartialView();
        }

        public ActionResult Statistic()
        {
            CounterDto CounterDto = GetCounter();
            WriteCounter();
            return PartialView(CounterDto);
        }

        public ActionResult Advertising()
        {
            return PartialView();
        }

        public ActionResult Category()
        {
            List<ProductDto> catList = _productHandler.GetComputerProducts();
            return PartialView(catList);
        }


        public CounterDto GetCounter()
        {
            CounterDto counter = new CounterDto();
            counter.All = int.Parse(ReadFile(Server.MapPath(CONST.COUNTER.PATH_ALL)));
            String today = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            counter.Today = int.Parse(ReadFile(Server.MapPath(CONST.COUNTER.PATH + today)));


            return counter;
        }

        public void WriteCounter()
        {
            String all = ReadFile(Server.MapPath(CONST.COUNTER.PATH_ALL));
            if (all == null || all == "") all = "0";
            int Counter_all = int.Parse(ReadFile(Server.MapPath(CONST.COUNTER.PATH_ALL))) + 1;
            String today = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            String countToday = ReadFile(Server.MapPath(CONST.COUNTER.PATH + today));
            if (countToday == null || countToday == "") countToday = "0";
            int Counter_today = int.Parse(countToday) + 1;
            WriteFile(Server.MapPath(CONST.COUNTER.PATH_ALL), Counter_all.ToString());
            WriteFile(Server.MapPath(CONST.COUNTER.PATH + today), Counter_today.ToString());
        }
        private String ReadFile(String filename)
        {
            StreamReader read = null;
            if (System.IO.File.Exists(filename) == false)
            {
                WriteFile(filename, "0");
                return "0";
            }
            else
            {
                try
                {
                    read = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read));
                    String outValue = read.ReadLine().Trim();

                    read.Close();
                    return outValue;
                }
                catch (Exception e)
                {
                }
                finally
                {
                    read.Close();
                }
                return "0";

            }
        }

        private void WriteFile(String filename, String content)
        {
            System.IO.FileStream f = null;
            StreamWriter writer = null;
            try
            {
                if (!System.IO.File.Exists(filename))
                {
                    f = System.IO.File.Create(filename);
                    f.Flush();
                    f.Close();
                }
                writer = new StreamWriter(filename);
                writer.WriteLine(content);
                writer.Flush();
                writer.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (f != null)
                    f.Close();
                if (writer != null)
                    writer.Close();
            }
        }

    }
}
