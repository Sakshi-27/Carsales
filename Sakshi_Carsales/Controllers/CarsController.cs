using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sakshi_Carsales.Models;

using System.IO;


namespace Sakshi_Carsales.Controllers
{
    public class CarsController : Controller
    {
        //GET: Cars/List
        public ActionResult List()
        {
            List<Cars> CarLists = new List<Cars>();
			using (var reader = new StreamReader(@"Database/Cars.csv"))
			{
				
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');
                    var car = new Cars() { Make = values[0], Model = values[1], Engine = values[2], Doors = values[3], Wheels= values[4], CarType = values[5] , Id = values[6]};
                    CarLists.Add(car);
				}
			}
           
            return View (CarLists);
        }

        public ActionResult Edit(String Id)
        {
            
           var car = new Cars();
            using (var reader = new StreamReader(@"Database/Cars.csv"))
            {
				 while (!reader.EndOfStream)
				 {
					  var line = reader.ReadLine();
					  var values = line.Split(',');
					  for (int i = 0; i <= values.Length; i++)
					  {
						  if(values[6] == Id)
						  {
							  car = new Cars() { Make = values[0], Model = values[1], Engine = values[2], Doors = values[3], Wheels = values[4], CarType = values[5], Id = values[6] };
						  }
					  }
				  }
			}

            return View(car);
        }

        public ActionResult Update(String Id, String Make, String Model, String Engine, String Doors, String Wheels, String Cartype)
        {
            /**StreamWriter Writer = new StreamWriter(@"Database/Cars.csv", false);
			using (var reader = new StreamReader(@"Database/Cars.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    for (int i = 0; i <= values.Length; i++)
                    {
                        if (values[6] == Id)
                        {
                            Writer.WriteLine(values[i].Replace(" ", " "));
						}
                    }
                }
               
            }

            **/
            return Content("Updated");
            
        
        }

    }
}
