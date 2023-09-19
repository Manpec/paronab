using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApplicationParonAB.Models;
using WebApplicationParonAB.Repositories;

namespace WebApplicationParonAB.Controllers
{
    [Route("api/[controller]")]
    public class ProdukterController : Controller
    {
        private readonly IProdukterRepository _produkterRepository;

        public ProdukterController(IProdukterRepository produkterRepository)
        {
            _produkterRepository = produkterRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _produkterRepository.GetAll  ();

            // Shape the data by selecting specific properties
            var result = products.Select(p => new
            {
                Produktnr = p.Produktnr,
                Benamning = p.Benamning,
                Pris = p.Pris
                // Include other properties as needed
            });

            return Ok(result); // Return the shaped data as JSON
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var produkt = _produkterRepository.GetById(id);

            if (produkt == null)
            {
                return NotFound(new { StatusCode =  404, Message = "Produkten kunde inte hittas." });
            }
            var result = new
            {
                Produktnr = produkt.Produktnr,
                Benamning = produkt.Benamning,
                Pris = produkt.Pris,
                // Include other properties as needed
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produkter produkt)
        {
            if (produkt == null)
            {
                return BadRequest(new { StatusCode = 400, Message = "Ogiltig begäran. Var god kontrollera fälten" });
            }

            _produkterRepository.Add(produkt);
            return CreatedAtAction(nameof(GetById), new { id = produkt.Produktnr }, produkt);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(string id, [FromBody] Produkter updatedProdukt)
        {
            if (updatedProdukt == null || id != updatedProdukt.Produktnr)
            {
                return BadRequest(new { StatusCode = 400, Message = "Ogiltig begäran. Var god kontrollera fälten" });
            }

            var existingProdukt = _produkterRepository.GetById(id);

            if (existingProdukt == null)
            {
                return NotFound(new { StatusCode = 404, Message = "Produkten kunde inte hittas." });
            }


            // Kontrollera om det nya namnet redan finns i databasen
            var produktWithSameName = _produkterRepository.Find(p => p.Benamning == updatedProdukt.Benamning).FirstOrDefault();

            if (produktWithSameName != null && produktWithSameName.Produktnr != id)
            {
                // Ett annat objekt med samma namn finns redan i databasen
                return BadRequest(new { StatusCode = 400, Message = "Namnet är redan taget. Välj ett annat namn." });
            }
            // Jämför de nya värdena med de befintliga värdena
            if (updatedProdukt.Benamning != existingProdukt.Benamning)
            {
                existingProdukt.Benamning = updatedProdukt.Benamning;
            }

            if (updatedProdukt.Pris != existingProdukt.Pris)
            {
                existingProdukt.Pris = updatedProdukt.Pris;
            }

            // Fortsätt jämföra och uppdatera andra egenskaper efter behov

            _produkterRepository.Update(existingProdukt);

            return Ok(existingProdukt);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var produkt = _produkterRepository.GetById(id);

            if (produkt == null)
            {
                return NotFound(new { StatusCode = 404, Message = "Produkten kunde inte hittas." });
            }

            _produkterRepository.Delete(produkt);
            return Ok(produkt);
        }
    }
}