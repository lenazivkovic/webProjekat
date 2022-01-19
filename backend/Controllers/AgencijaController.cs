using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace trip_it.Controllers{

    [ApiController]
    [Route("api/admin/Agencija")]
    public class AgencijaController:ControllerBase{

        public TripITContext Context { get; set; }

        public AgencijaController(TripITContext context){
            Context = context;
        }


        [HttpGet]
        public async Task<ActionResult> getAgenciju(int idAgencije = 0){
            if(idAgencije < 0)
                return BadRequest("Nevalidan ID");

            if(idAgencije == 0){
                var data = await Context.agencija.ToListAsync();
                return Ok(data);

            }else{
                var data = await Context.agencija.FindAsync(idAgencije);

                if(data == null) return NotFound("Ne postoji agencija sa tim ID-jem");            
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<ActionResult> dodajAgenciju(Agencija a){
            Context.agencija.Add(a);
            try{
                await Context.SaveChangesAsync();
                return Ok("Sve je u redu !");  
            }catch{
                return BadRequest("Greska pri dodavanju");
            }
                      
        }

        
        [HttpPut]
        public async Task<ActionResult> menjajAgenciju(int ID,Agencija temp){
            var podatak = Context.agencija.Find(ID);
            if(podatak == null) return NotFound("Podatak nije nadjen !");

            podatak.imeAgencije = temp.imeAgencije;
            podatak.kontaktTelefon = temp.kontaktTelefon;
            podatak.email = temp.email;
            podatak.adresa = temp.adresa;
            
            await Context.SaveChangesAsync();
            return Ok("Podatak izmenjen !");
             
        }

        [HttpDelete]
        public async Task<ActionResult> deleteAgenciju(int ID){
            if(ID < 0){
                return BadRequest("Neispravan ID");
            }

            try{
                var pon = Context.agencija.Find(ID);
                if(pon != null)
                {
                    Context.agencija.Remove(pon);

                    await Context.SaveChangesAsync();
                    return Ok("Sve je u redu.");
                }else
                    return NotFound("Ne postoji agencija sa ID:" + ID.ToString());
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }

}