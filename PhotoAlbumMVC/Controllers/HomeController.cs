using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace PhotoAlbumMVC.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult AlbumSuggestions(string albumID)
        {
            string baseUrl = "https://jsonplaceholder.typicode.com/photos";

            int i;

            if (int.TryParse(albumID.ToString(), out i))
            {
                baseUrl = baseUrl + "?albumId=" + albumID.ToString();
            }

            var json = new WebClient().DownloadString(baseUrl);

            List<PhotoAlbumMVC.Models.Album> album = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Album>>(json);

            return this.Json(
              new
              {
                  sEcho = album.Count(),
                  iTotalRecords = album.Count(),
                  iTotalDisplayRecords = album.Count(),
                  aaData = album.Select(a => new
                  {
                      albumId = a.albumID,
                      id = a.ID,
                      title = a.title,
                      url = a.url,
                      thumbnailUrl = a.thumbnailUrl,
                  })
              }
              , JsonRequestBehavior.AllowGet
              );
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}