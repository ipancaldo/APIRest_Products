using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using Logic;

namespace MVC.Controllers
{
    public class PublicApiController : Controller
    {
        public ActionResult Index()
        {
            var url = $"https://dog.ceo/api/breeds/image/random";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            var dog = JsonConvert.DeserializeObject<PublicApiView>(responseBody);

                            return View(dog);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
        
        public ActionResult Cat()
        {
            var url = $"https://aws.random.cat/meow";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            var cat = JsonConvert.DeserializeObject<CatApiView>(responseBody);

                            return View(cat);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
    }
}