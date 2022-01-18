import { Rezervacija } from "./Rezervacija.js";

export class ListaRezervacija{

    rezervacije = [];
    
    constructor(jmbg){
        this.jmbg = jmbg;
    }

    loadData(){
        var request = new XMLHttpRequest();
        request.open('GET',"https://localhost:5001/api/Rezervacija?ID=-1&JMBG="+this.jmbg, false);  // `false` makes the request synchronous
        
        request.send(null);
        
        let data = JSON.parse(request.response);
        
        data.forEach(el => {
            this.rezervacije.push(new Rezervacija(el.id,el.klijent,el.ponuda,el.brojDana,el.brojOsoba));
        })

        console.log(this.rezervacije);
    }

    draw(container){
    
        let rez = document.createElement("div");
        rez.classList.add("ponude");
        container.appendChild(rez);

        this.rezervacije.forEach(el => {
            el.draw(rez);
        });
    }
}