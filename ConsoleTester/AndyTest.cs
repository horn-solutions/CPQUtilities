using CPQUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace ConsoleTester
{
    public static class AndyTest
    {
        public static void test(string[] args)
        {




            //CPQ Add a Product:
            Credentials c = new Credentials();
            
            Console.Write(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe() ? "Successful" : "Unsuccessful"));

            //Create Product:
            Product p = new Product();
            //define Product Name(REQUIRED!!)
            p.ProductName = new ProductList();
            p.ProductName.Add(new Translations("AndyProductAPITest1"));

            //define Product Category (REQUIRED!)
            p.Categories = new CategoryList();
            p.Categories.Add(new Translations("Software Devices"));

            //define Product Type(REQUIRED!)
            p.ProductType = "Software";

            //define Product display type? (defaults to Simple product if node not included, recommend not to include in general, only include when not wanting a simple product)
            p.DisplayType = "Configurable";
            //p.DisplayType = ProductDisplayType.Configurable; 
            

            //define Active State (not required), defaults to true if missing;
            p.Active = true;

            //define Attribute names
            p.AttributeName = new AttributeList();
            p.AttributeName.Add(new Translations("Attribute1"));

            //define Attribute values
            p.AttributeValue = new AttributeValueList();
            p.AttributeValue.Add(new Translations("500"));

            Console.WriteLine("----------");
           
            //this doesn't do what you think it does.
            Console.WriteLine("Inner XML: " + p.CreateXml().InnerXml);
            
            
            //Attempt to Push the product and any defined variables for that product
            Push.Product(p, c);
            Console.WriteLine("Tried to push product");

            //probably, when looping through above for mulitple products, should attempt to clear lists so as not to duplicate?
            //example: p.AttributeName.Clear();

            //Excel code:

            //Excel.Application app = new Excel.Application();

            /////*
            //// * this is important, if your code crashes, excel will be running but invisible.  
            //// * 
            //// * check your running processes frequently when doing excel work
            //// * 
            //// * having excel visible while making changes is dangerous because someone could click and it runs much slower
            //// */
            //app.Visible = true;
            //string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Excel.Workbook wbin = app.Workbooks.Open(Path.Combine(path, "sample.xlsx"));
            //Excel.Workbook wbout = app.Workbooks.Add();

            ////all interop libraries use 1 based indexing (0 is NOT the first element)
            //Excel.Worksheet wsin = wbin.Worksheets[1];
            //Excel.Worksheet wsout = wbout.Worksheets[1];

            //wsout.Cells[1, 1] = "Status";
            //wsout.Cells[1, 2] = wsin.Cells[1, 1];
            //wsout.Cells[1, 3] = wsin.Cells[1, 2];
            //wsout.Cells[1, 4] = wsin.Cells[1, 3];

            //for (int line = 2; line <= 4; line++)
            //{
            //    wsout.Cells[line, 1] = "Success";
            //    for (int col = 1; col <= 3; col++)
            //        wsout.Cells[line, col + 1] = wsin.Cells[line, col];
            //}

            Console.ReadLine();

        }

       
    }
}
