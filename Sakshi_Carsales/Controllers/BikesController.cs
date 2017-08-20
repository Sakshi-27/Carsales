using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sakshi_Carsales.Models;
using System.IO;

namespace Sakshi_Carsales.Controllers
{
    public class BikesController : Controller
    {
		public ActionResult List()
		{
            List<Bikes> BikeLists = new List<Bikes>();
			using (var reader = new StreamReader(@"Database/Bikes.csv"))
			{

				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');
					var bike = new Bikes() { Make = values[0], Model = values[1], Engine = values[2], Wheels = values[3], BikeType = values[4], Id = values[5] };
					BikeLists.Add(bike);
				}
			}

			return View(BikeLists);
		}

		public ActionResult Edit(String Id)
		{

			var bike = new Bikes();
			using (var reader = new StreamReader(@"Database/Bikes.csv"))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');
					for (int i = 0; i <= values.Length; i++)
					{
						if (values[5] == Id)
						{
							bike = new Bikes() { Make = values[0], Model = values[1], Engine = values[2],  Wheels = values[3], BikeType = values[4], Id = values[5] };
						}
					}
				}
			}

			return View(bike);
		}

		public ActionResult Update(String Id, String Make, String Model, String Engine, String Wheels, String Cartype)
		{
			/**StreamWriter Writer = new StreamWriter(@"Database/Bikes.csv", false);
            using (var reader = new StreamReader(@"Database/Bikes.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    for (int i = 0; i <= values.Length; i++)
                    {
                        if (values[5] == Id)
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
