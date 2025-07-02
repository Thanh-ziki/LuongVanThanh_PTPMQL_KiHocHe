using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace DemoMVc.Controllers
{
    public class HelloWorldController : Controller
    { 
        // GET: /HelloWorld/
        public string Index()
        {
            return "This is my default action...";
        } 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "Bài Test PTPMQL";
        }
    }
}
