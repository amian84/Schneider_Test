using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Class1
    {
        public void createTest(string texr)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            string path = (System.IO.Path.GetDirectoryName(executable));
            path = System.IO.Path.Combine(path, "backend.sqlite").Replace("file:\\", "");
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            using (var db = new DataModel())
            {
                Test test = new Test();
                test.text = texr;
                //db.Database.ExecuteSqlCommand("CREATE TABLE 'Test' ('text'    TEXT); ");
                db.Tests.Add(test);
                db.SaveChanges();
            }
        }
    }
}
