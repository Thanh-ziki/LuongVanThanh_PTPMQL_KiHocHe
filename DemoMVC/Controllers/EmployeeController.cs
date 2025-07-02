using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace DemoMVc.Controllers
{
    public class EmployeeController : Controller
    { 
         public IActionResult Index()
        {
            return View();
        } 
        
        public string Welcome()
        {
            return "Wecome my PC";
        } 
        
    }
}
