using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;

namespace trip_it.Controllers{

    [ApiController]
    [Route("api/Klijent")]
    public class KlijentController:ControllerBase{

         public TripITContext Context { get; set; }

         public KlijentController(TripITContext context){
             Context = context;
         }

        [HttpGet]
        public async Task<ActionResult> getKlijenta(string JMBG){
            
            if(string.IsNullOrWhiteSpace(JMBG))
            {
                var data = await Context.klijent
                    .ToListAsync();
                return Ok(data);
            }
            else{
                var data = await Context.klijent
                        .Where(p => p.JMBG == JMBG)
                        .ToListAsync();
                if(data.Any())
                    return Ok(data.First());
                else
                    return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> noviKlijent([FromBody] Klijent k){

            if(string.IsNullOrWhiteSpace(k.imeKlijenta) || k.imeKlijenta.Length > 50){
                return BadRequest("Lose uneto ime klijenta.");
            }

            if(string.IsNullOrWhiteSpace(k.prezimeKlijenta) || k.prezimeKlijenta.Length > 50){
                return BadRequest("Lose uneto prezime klijenta.");
            }

            if(string.IsNullOrWhiteSpace(k.JMBG) || k.JMBG.Length != 13){
                return BadRequest("Lose unet JMBG.");
            }

             if(string.IsNullOrWhiteSpace(k.grad) || k.grad.Length > 50){
                return BadRequest("Lose uneto ime grada.");
            }

             if(string.IsNullOrWhiteSpace(k.adresa) || k.adresa.Length > 50){
                return BadRequest("Lose uneta adresa.");
            }

             if(string.IsNullOrWhiteSpace(k.kontaktTelefon) || k.kontaktTelefon.Length < 9){
                return BadRequest("Lose unet broj telefona.");
            }

            try{
                Context.klijent.Add(k);
                await Context.SaveChangesAsync();
                return Ok("sve je u redu");
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> obrisiKlijenta(int ID){

            if(ID < 0)
                return BadRequest("Neispravan ID.");
            
            try{
                var data = Context.klijent.Find(ID);
                if(data != null)
                {
                    Context.klijent.Remove(data);

                    await Context.SaveChangesAsync();
                    return Ok("Sve je u redu.");
                }else
                    return NotFound("Ne postoji rezervacija sa ID:" + ID.ToString());
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}