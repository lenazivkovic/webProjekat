using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;


namespace Controllers
{

    [ApiController]
    [Route("api/Rezervacija")]
    
    public class RezervacijaController:ControllerBase
    {
        public TripITContext Context { get; set; }

        public RezervacijaController(TripITContext context){
            Context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult> getRez(int ID = -1, string JMBG = "none"){
            if(ID == -1 && JMBG == "none")
            {
                var data = await Context.rezervacija
                .Include(p => p.klijent)
                .Include(p => p.ponuda)
                .Include(p => p.ponuda.lokacija)
                .ToListAsync();
                return Ok(data);
            }else if(JMBG != "none"){
                var data = await Context.rezervacija
                .Where(p => p.klijent.JMBG == JMBG)
                .Include(p => p.klijent)
                .Include(p => p.ponuda)
                .ThenInclude(p => p.lokacija)
                .ToListAsync();
                return Ok(data);
            }else{
                
                var data = await Context.rezervacija
                .Where(p => p.ID == ID)
                .Include(p => p.klijent)
                .Include(p => p.ponuda)
                .Include(p => p.ponuda.lokacija)
                .ToListAsync();
                if(data.Any())
                    return Ok(data);
                else
                    return NotFound();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Rezervisi(string JMBG, int IDponude,int brojOsoba, int brojDana){

            if(string.IsNullOrWhiteSpace(JMBG))
                return BadRequest("Neispravan JMBG");
            if(IDponude < 0)
                return BadRequest("Neispravan ID ponude.");

            try{
                Rezervacija rez = new Rezervacija();
                Ponuda po = Context.ponuda.Find(IDponude);
                Klijent kli = Context.klijent
                                .Where(p => p.JMBG == JMBG) 
                                .First();
                if(kli != null)
                    rez.klijent = kli;
                else
                    return BadRequest("Nevalidni JMBG.");

                rez.ponuda = po;
                rez.brojOsoba = brojOsoba;
                rez.brojDana = brojDana;

                Context.rezervacija.Add(rez);
                await Context.SaveChangesAsync();
                return Ok();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        } 

        [HttpPut]
        public async Task<ActionResult> Menjaj(int ID, int brojDana, int brojOsoba){
            if(ID < 0)
                return BadRequest("Nevalidan JMBG!");
            
            var data = Context.rezervacija.Find(ID);

            if(data == null)
                return NotFound("Ne postoji rezervacija sa ID-jem "+ID);

            data.brojDana = brojDana;
            data.brojOsoba = brojOsoba;
                        
            await Context.SaveChangesAsync();
            return Ok("Uspesno azurirana rezervacija");
        }


        [HttpDelete]
        public async Task<ActionResult> Obrisi(int ID){
            if(ID < 0){
                return BadRequest("Neispravan ID");
            }

            try{
                var rez = Context.rezervacija.Find(ID);
                if(rez != null)
                {
                    Context.rezervacija.Remove(rez);

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