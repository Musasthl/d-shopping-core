using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Service.DTO;

namespace Service.Handler
{
    public class CounterHandler
    {
        public CounterDto GetCounter()
        {
            CounterDto counter = new CounterDto();
            counter.All = int.Parse(ReadFile(CONST.COUNTER.PATH_ALL));
            String today = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            counter.Today = int.Parse(ReadFile(CONST.COUNTER.PATH + today));


            return counter;
        }

        public void WriteCounter()
        {
            String all = ReadFile(CONST.COUNTER.PATH_ALL);
            if (all == null || all == "") all = "0";
            int Counter_all = int.Parse(ReadFile(CONST.COUNTER.PATH_ALL)) + 1;
            String today = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            String countToday = ReadFile(CONST.COUNTER.PATH + today);
            if (countToday == null || countToday == "") countToday = "0";
            int Counter_today = int.Parse(countToday) + 1;
            WriteFile(CONST.COUNTER.PATH_ALL, Counter_all.ToString());
            WriteFile(CONST.COUNTER.PATH + today, Counter_today.ToString());
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
                if (!File.Exists(filename))
                {
                    f = File.Create(filename);
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
