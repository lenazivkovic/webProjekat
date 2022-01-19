using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;


namespace trip_it.Controllers{

    [ApiController]
    [Route("api/Lokacija")]
    public class LokacijaController:ControllerBase{

        public TripITContext Context { get; set; }

        public LokacijaController(TripITContext context){
            Context = context;
        }

        [HttpGet]
        public ActionResult Prikazi(int ID = -1){
            if(ID == -1)
                return Ok(Context.lokacija);
            else{
                var data = Context.lokacija
                .Where(p => p.ID == ID)
                .ToList();
                if(data.Any())
                    return Ok(data);
                else
                    return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> DodatiLokaciju([FromBody] Lokacija lok){
            
            if(string.IsNullOrWhiteSpace(lok.drzava) || lok.drzava.Length > 50){
                return BadRequest("Lose uneto ime drzave.");
            }

            if(string.IsNullOrWhiteSpace(lok.grad) || lok.grad.Length > 50){
                return BadRequest("Lose uneto ime grada.");
            }

            if(string.IsNullOrWhiteSpace(lok.hotel) || lok.hotel.Length > 50){
                return BadRequest("Lose uneto ime hotela.");
            }

            try{
                Context.lokacija.Add(lok);
                await Context.SaveChangesAsync();
                return Ok("sve je u redu");
            }catch(Exception e){
                return BadRequest(e.Message);
            }
            
            
        }
        [HttpGet]
        [Route("Drzave")]
        public ActionResult getDrzave(){
            var data = Context.lokacija;
            var dict = new List<string>();
            foreach (var item in data)
            {
                if(dict.Contains(item.drzava) == false)
                    dict.Add(item.drzava);
            }
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(dict));
        }

        [HttpGet]
        [Route("Gradovi")]
        public ActionResult getGradovi(string drzava){
            var data = Context.lokacija
            .Where(p => p.drzava == drzava)
            .ToList();

            var dict = new List<string>();
            foreach (var item in data)
            {
                if(dict.Contains(item.grad) == false)
                    dict.Add(item.grad);
            }
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(dict));
        }
        
        [HttpPut]
        public async Task<ActionResult> PromeniLokaciju(int ID,string drzava, string grad, string hotel){
            
            if(ID < 0){
                return BadRequest("Neispravan ID.");
            }
            try{

                var lok = Context.lokacija.Where(p => p.ID == ID).FirstOrDefault();

                if(lok != null){
                    lok.drzava = drzava;
                    lok.grad = grad;
                    lok.hotel = hotel;

                    await Context.SaveChangesAsync();
                    return Ok($"Promenili ste lokaciju sa ID: {lok.ID}");
                } else{
                    return BadRequest("Nepostojeca lokacija.");
                }
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> IzbrisiLokaciju(int ID){
            if(ID < 0){
                return BadRequest("Neispravan ID.");
            }

            try{

                var lok = Context.lokacija.Find(ID);
                Context.lokacija.Remove(lok);

                await Context.SaveChangesAsync();

                return Ok($"Izbrisana lokacija sa ID: {lok.ID}");
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }

}