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

            ////Add a Product
            //Console.Write("Calling Add Product Code:");
            //AddProduct();

            ////Add a Customer:
            //Console.Write("Call Add Customer Code:");
            // AddCustomer();

            ////Add a User:
            //Console.Write("Call Add User Code:");
            //AddUser();

            ////Add a Company:
            //Console.WriteLine("Call Add Company Code:");
            //AddCompany();
            Console.WriteLine("The Desciption for API Error code: 100019 is: " + Get.GetAPIErrorDescription("100019"));

            Console.WriteLine("Generated random password: " + Utility.RandomPassword());

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

        public static void AddProduct()
        {
         //   //[][][][][CPQ ADD A PRODUCT][][][][]
         //   //Credentials Information
            Credentials c = new Credentials();

          //  //Test Credentials for instance:
            Console.WriteLine(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe() ? "Successful" : "Unsuccessful"));

          //  //Create Product:
            Product p = new Product();

          //  //[][][][][DEFINE PRODUCT NAME(REQUIRED!)][][][][]
            p.ProductName = new ProductList();
            p.ProductName.Add(new Translations("AndyProductAPITest1"));

          //  //[][][][][DEFINE PRODUCT CATEGORY(REQUIRED!)][][][][]
            p.Categories = new CategoryList();
            p.Categories.Add(new Translations("Software Devices"));

          //  //[][][][][DEFINE PRODUCT TYPE(REQUIRED!)][][][][]
            p.ProductType = "Software";

           // //[][][][][DEFINE PRODUCT DISPLAY TYPE][][][][]
           // //(defaults to Simple product if node not included, recommend not to include in general, 
           // //only include when not wanting a simple product, otherwise just comment out)
            p.DisplayType = "Configurable";
            //p.DisplayType = ProductDisplayType.Configurable; 

            ////[][][][][DEFINE ACTIVE STATE][][][][]
            ////define Active State (not required), defaults to true if missing;
            p.Active = true;

           // //[][][][][ATTRIBUTES][][][][]
           // //define Attribute names
            p.AttributeName = new AttributeList();
            p.AttributeName.Add(new Translations("Attribute1"));
            ////define Attribute values
            p.AttributeValue = new AttributeValueList();
            p.AttributeValue.Add(new Translations("500"));

            Console.WriteLine("----------");

            //show XML generated from above, that will be pushed to CPQ for adding products:
            Console.WriteLine("Inner XML: " + p.CreateXml().InnerXml);

            ////Attempt to Push the product and any defined variables for that product:
            //Push.Product(p, c); //comment this out when not wanting to push products
            //Console.WriteLine("Tried to push product");

            ////probably, when looping through above for mulitple products, should attempt to clear lists so as not to duplicate?
            ////example: p.AttributeName.Clear();
        }

        public static void AddCustomer()
        {

            //  < Customers >
            //    < Customer >
            //      < Id > 23 </ Id >
            //      < ExternalId ></ ExternalId >
            //      < Active > 0 </ Active >
            //      < FirstName > Harry </ FirstName >
            //      < LastName > Bruce </ LastName >
            //      < CustomerType ></ CustomerType >
            //      < Company > Procter & amp; Gamble Company, The</Company>
            //      <Address1>Procter &amp; Gamble Plaza</Address1>
            //      <Address2></Address2>
            //      <City>Cincinnati</City>
            //      <Province></Province>
            //      <StateAbbrev>OH</StateAbbrev>
            //      <ZipCode>45402</ZipCode>
            //      <CountryAbbrev>US</CountryAbbrev>
            //      <TerritoryName></TerritoryName>
            //      <BusinessPhone>(513) 698-6421</BusinessPhone>
            //      <BusinessFax>(513) 983-4381</BusinessFax>
            //      <EMail></EMail>
            //      <OwnerID>234</OwnerID>
            //      <OwnerUserName>MitchB</OwnerUserName>
            //      <CRMAccountId>0036000000Kq8eU</CRMAccountId>
            //      <CRMContactId>0016000000F0qvQ</CRMContactId>
            //      <CustomFields>
            //	<CustomField>
            //	   <Name>CustomCode</Name>
            //	   <Value>AAA111</Value>
            //	</CustomField>
            //      </CustomFields>
            //    </Customer>

            //   //Credentials Information
            Credentials c = new Credentials();

            //  //Test Credentials for instance:
            Console.WriteLine(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe2() ? "Successful" : "Unsuccessful"));

            Customer cust = new Customer();

            cust.FirstName = "Jimmy";
            cust.LastName = "CrackCorn";
            cust.Company = "Customer Co";
            cust.Address1 = "123 First Street";
            cust.City = "Eureka";

            Console.WriteLine("Inner XML: " + cust.CreateXml().InnerXml);

            ////Attempt to Push the Customer and any defined variables for that Customer:
            //Push.Customer(cust, c);  //currently, returns incorrect login, unsure why...
            Console.WriteLine("Tried to push customer");

            ////probably, when looping through above for mulitple customers, should attempt to clear lists so as not to duplicate?
            ////example: cust.AttributeName.Clear();

        }

        public static void AddUser()
        {
            Credentials c = new Credentials();
            Console.Write(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe() ? "Successful" : "Unsuccessful"));
            User u = new User()
            {
                Username = "Duder",
                Password = "123123",
                FirstName = "Duder",
                LastName = "Dudie"
            };

            Console.WriteLine(u.CreateXml().InnerXml);

           // Push.User(u, c);
           // Console.WriteLine("Tried to push user");




        }

        public static void GetCatalogue()
        {
            Credentials c = new Credentials();
            Console.Write(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe2() ? "Successful" : "Unsuccessful"));

            //Get Catalogue info:
            Console.WriteLine(Get.Catalogue(c));

            
        }

        public static void AddCompany()
        {

            //<COMPANYPROPERTIES>
            //  <COMPANYCODE>WBI</COMPANYCODE >
            //  <NAME>Webcom, Inc</NAME>
            //  <EMAILADDRESS>webmaster @webcominc.com</EMAILADDRESS>
            //  <ADDRESS1>611 N Broadway</ADDRESS1>
            //  <ADDRESS2 />
            //  <CITY>Milwaukee</CITY>
            //  <STATE>WI</STATE>
            //  <ZIPCODE>53202</ZIPCODE>
            //  <COUNTRY>United States</COUNTRY>
            //  <PHONENUMBER>414-273-4442</PHONENUMBER>
            //  <FAXNUMBER> 414-298-9248 </FAXNUMBER>
            //  <IMAGE>Webcomlogo.gif</IMAGE>
            //</COMPANYPROPERTIES>


            //add a company
            Credentials c = new Credentials();
            Console.Write(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe() ? "Successful" : "Unsuccessful"));

            Console.WriteLine("----------");
            Company company = new Company();

            company.CompanyCode = "TestComp";
            company.Name = "TestCompany";
            company.Address1 = "123 N Test Street";
            company.City = "Test City";
            company.State = "TX";


            //show XML generated from above, that will be pushed to CPQ for adding company:
            Console.WriteLine("Inner XML: " + company.CreateXml().InnerXml);

            ////Attempt to Push the company and any defined variables for that company:
            //Push.Company(company, c); //comment this out when not wanting to push company
            //Console.WriteLine("Tried to push company");

            ////probably, when looping through above for mulitple companies, should attempt to clear lists so as not to duplicate?
            ////example: p.AttributeName.Clear();
            

        }

    }
}
