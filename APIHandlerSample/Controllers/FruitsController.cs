using APIHandlerSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIHandlerSample.Controllers
{
    public class FruitsController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetDailyFruit(DailyFruitParam param)
        {
            DateTime DateTimeIn = DateTime.Now;
            try
            {
                if (param.CustomerID != 0)
                {
                    DailyFruit fruit = new DailyFruit
                    {
                        //this part can be fetched from a db or thridpartyapi
                        Name = "Apple",
                        Description = "An apple is a round, edible fruit produced by an apple tree (Malus spp., among them the domestic or orchard apple; Malus domestica). Apple trees are cultivated worldwide and are the most widely grown species in the genus Malus. The tree originated in Central Asia, where its wild ancestor, Malus sieversii, is still found. Apples have been grown for thousands of years in Eurasia and were introduced to North America by European colonists. Apples have religious and mythological significance in many cultures, including Norse, Greek, and European Christian tradition.",
                        Caption = "Take an apple a dya keep the doctor away"
                    };

                    if (fruit != null)
                    {
                        var message = Request.CreateResponse(HttpStatusCode.OK, fruit);
                        message.Headers.Location = new Uri(Request.RequestUri.ToString());
                        return message;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fruit Not Found");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            catch (Exception Ex)
            {               
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "BadRequest");
            }

        }
    }
}