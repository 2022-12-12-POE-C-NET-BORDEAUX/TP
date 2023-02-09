using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exemple.Models;


namespace Exemple.Controllers;

public class HomeController : Controller
{
	public HomeController()
	{
		TrelloContext context = new();
	}

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}
}
