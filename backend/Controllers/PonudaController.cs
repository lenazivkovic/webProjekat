using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace trip_it.Controllers{

    [ApiController]
    [Route("api/Ponuda/")]
    public class PonudaController:ControllerBase{

        public TripITContext Context { get; set; }

        public PonudaController(TripITContext context){
            Context = context;
        }

        [Route("Filter")]
        [HttpGet]
        public async Task<ActionResult> filtriraj(int idAgencije ,string grad,DateTime datumMin,DateTime datumMax, int minCena = 0,int maxCena = 0){
            
            if(maxCena == 0){
                var data = await Context.ponuda
                .Where(p => p.lokacija.grad == grad && 
                    p.cena > minCena && 
                    p.datum.Date > datumMin.Date && 
                    p.datum.Date < datumMax.Date && 
                    p.agencija.ID == idAgencije
                )
                .Include(p => p.lokacija)
                .Include(p => p.agencija)
                .ToListAsync();
                if(data.Any() == true)
                    return Ok(data);
                else
                    return NotFound();
            }else if(string.IsNullOrWhiteSpace(grad)){
                var data = await Context.ponuda
                .Where(p =>  p.cena > minCena && p.cena < maxCena && p.datum.Date > datumMin.Date 
                        && p.datum.Date < datumMax.Date)
                .Include(p => p.lokacija)
                .Include(p => p.agencija)
                .ToListAsync();
                if(data.Any() == true)
                    return Ok(data);
                else
                    return NotFound();
            }else{
                var data = await Context.ponuda
                .Where(p => p.lokacija.grad == grad && p.cena > minCena && p.cena < maxCena && 
                        p.datum.Date > datumMin.Date && p.datum.Date < datumMax.Date)
                .Include(p => p.lokacija)
                .Include(p => p.agencija)
                .ToListAsync();
                if(data.Any() == true)
                    return Ok(data);
                else
                    return NotFound();
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> Prikaz(int ID = -1){
            if(ID == -1)
            {
                var data = await Context.ponuda
                .Include(p => p.lokacija)
                .ToListAsync();
                return Ok(data);
            }else{
                
                var data = await Context.ponuda
                .Where(p => p.ID == ID)
                .Include(p => p.lokacija)
                .ToListAsync();
                if(data.Any())
                    return Ok(data);
                else
                    return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Dodaj(int IDLok,int IDAg,int cena,DateTime datum){

            if(IDLok < 0){
                return BadRequest("Neispravan ID");
            }

            if(cena <= 0){
                return BadRequest("Neispravna cena.");
            }

            try{
                Ponuda pon = new Ponuda();
                Lokacija lok = Context.lokacija.Find(IDLok);
                Agencija ag = Context.agencija.Find(IDAg);

                pon.lokacija = lok;
                pon.cena = cena;
                pon.datum = datum;
                pon.agencija = ag;

                Context.ponuda.Add(pon);
                await Context.SaveChangesAsync();

                return Ok("Sve je u redu.");
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        //[Route("/")]
        [HttpPut]
        public async Task<ActionResult> Promeni(int ID, int IDLok,int IDag,int cena, DateTime datum){

            if(ID < 0){
                return BadRequest("Neispravan ID ponude.");
            }
            if(IDLok < 0){
                return BadRequest("Neispravan ID lokacije.");
            }
            if(IDag < 0){
                return BadRequest("Neispravan ID agencije.");
            }
            if(cena <= 0){
                return BadRequest("Neispravan iznos cene");
            }

            try{
                var pon = Context.ponuda.Where(p => p.ID == ID).FirstOrDefault();

                if(pon != null){
                    Lokacija lok = Context.lokacija.Find(IDLok);
                    Agencija ag = Context.agencija.Find(IDag);

                    pon.agencija = ag;
                    pon.lokacija = lok;
                    pon.cena = cena;
                    pon.datum = datum;

                    await Context.SaveChangesAsync();
                    return Ok("Sve je u redu.");
                }else{
                    return BadRequest("Pokusajte ponovo.");
                }
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Obrisi(int ID){
            if(ID < 0){
                return BadRequest("Neispravan ID");
            }

            try{
                var pon = Context.ponuda.Find(ID);
                if(pon != null)
                {
                    Context.ponuda.Remove(pon);

                    await Context.SaveChangesAsync();
                    return Ok("Sve je u redu.");
                }else
                    return NotFound("Ne postoji ponuda sa ID:" + ID.ToString());
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }

}