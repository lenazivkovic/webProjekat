import { Ponuda } from "./Ponuda.js";

export class ListaPonuda{

    constructor(idAgencije,grad, minimumCena,maximumCena,datumMin,datumMax){
        this.idAgencije = idAgencije;
        this.grad = grad;
        this.minimumCena = minimumCena;
        this.maximumCena = maximumCena;
        this.datumMin = datumMin;
        this.datumMax = datumMax;
    }

    draw(container){
       
        fetch("https://localhost:5001/api/Ponuda/Filter?"+"idAgencije="+this.idAgencije+"&grad="+this.grad+"&datumMin="+
            this.datumMin + "&datumMax="+ this.datumMax +"&minCena="+this.minimumCena+"&maxCena="+this.maximumCena)
        .then(p => p.json())
        .then(p => {
            p.forEach(el => {
                let p = new Ponuda(el.id,el.lokacija,el.cena,el.datum,el.lokacija.slika);
                p.draw(container); 
            })
        })
        .catch(err => {
            alert("Nemamo tu ponudu trenutno u agenciji!");
            console.error(err);
        });
    }
}