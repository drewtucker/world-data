using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using WorldDataApp.Models;

namespace WorldDataApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/cities")]
    public ActionResult Cities()
    {
      return View();
    }

    [HttpGet("/population")]
    public ActionResult Population()
    {
      return View();
    }

    [HttpGet("/america")]
    public ActionResult USA()
    {
      return View();
    }

  }
}
