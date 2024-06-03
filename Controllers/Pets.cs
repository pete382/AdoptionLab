using AdoptionLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace AdoptionLab.Controllers
{
    public class Pets : Controller
    {  PetsContext PetsTL = new PetsContext();
        public IActionResult Index()
        {
            List<PetCategory> Result1 = PetsTL.PetCategories.ToList();
            return View(Result1);
        }

        public IActionResult Detail(int Id)
        {
            PetCategory Result1 = PetsTL.PetCategories.FirstOrDefault(a => (int)a.Id == Id);

            
			List<Pet> Result2 = PetsTL.Pets.Where(a => a.Breed ==  Result1.Id).ToList();

		  
            return View(Result2);

        }

        [HttpGet]
        public IActionResult Adopt(int Id)
        {
            Pet Adoption = PetsTL.Pets.FirstOrDefault(a => a.Id == Id);

            PetsTL.Pets.Remove(Adoption);
            PetsTL.SaveChanges();
            return RedirectToAction("Index");
                     

        }


        [HttpPost]
        public IActionResult AddPet(Pet Pet)
        {

            PetsTL.Pets.Add(Pet);
            PetsTL.SaveChangesAsync();

        
            return RedirectToAction("Index");
        }






    }
}
