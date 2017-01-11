using API.RareCarat.Example.Model;
using API.RareCarat.Example.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.RareCarat.Example.Controllers
{
    public class HomeController : Controller
    {
        private IAPIService APIService;
        private IDiamondService DiamondService;

        public HomeController(IDiamondService diamondService, IAPIService apiService)
        {
            DiamondService = diamondService;
            APIService = apiService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/ViewLocal
        public IActionResult ViewLocal()
        {
            var diamonds = DiamondService.GetAll();
            return View(diamonds);
        }

        // GET: /<controller>/list
        public async Task<IActionResult> List()
        {
            var result = await APIService.Get();
            return View(result);
        }

        // GET: /<controller>/create
        public async Task<IActionResult> Create()
        {
            var diamonds = DiamondService.GetAll();
            var result = await APIService.Create(diamonds);
            return View(result);
        }

        // GET: /<controller>/update
        public async Task<IActionResult> Update(string id)
        {
            APIResponse result;

            if (!string.IsNullOrEmpty(id))
            {
                var data = new
                {
                    Price = 5999
                };
                result = await APIService.Update(id, data);
            }
            else
            {
                var diamond = DiamondService.GetAll().FirstOrDefault();
                if (diamond != null)
                {
                    result = await APIService.Update(diamond);
                }
                else
                {
                     result = new APIResponse() { StatusCode = 404, Content = "" };
                }
            }
            return View(result);
        }

        // GET: /<controller>/delete
        public async Task<IActionResult> Delete(string id)
        {
            var result = (!string.IsNullOrEmpty(id) 
                ? await APIService.Delete(id) 
                : await APIService.DeleteAll() 
            );

            return View(result);
        }
    }
}
