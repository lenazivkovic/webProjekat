import { Klijent } from "./Klijent.js";
import { Ponuda } from "./Ponuda.js";

export class Rezervacija{
    constructor(id,klijent,ponuda,brojDana,brojOsoba){
        this.id = id;
        this.klijent = klijent;
        this.ponuda = ponuda;
        this.brojDana = brojDana;
        this.brojOsoba = brojOsoba;
    }

    getFromDatabase(id){
        fetch("https://localhost:5001/api/Rezervacija?ID="+id)
        .then(res => res.json())
        .then(data => {
            this.id = data.id;
            this.klijent = data.klijent;
            this.ponuda = data.ponuda;
            this.brojDana = data.brojDana;
            this.brojOsoba = data.brojOsoba;
        })
        .catch(err => console.log(error));

        
    }

    draw(container){

        let row = document.createElement("div");
        row.classList.add("pregled");
        row.classList.add("border");
        let polje1 = document.createElement("h5");
        polje1.classList.add("podaci");
        let polje2 = document.createElement("h5");
        polje2.classList.add("podaci");
        let polje3 = document.createElement("h5");
        polje3.classList.add("podaci");
        let polje4 = document.createElement("h5");
        polje4.classList.add("podaci");

        polje1.innerHTML = "Država: " + this.ponuda.lokacija.drzava;
        polje2.innerHTML = "Grad: " + this.ponuda.lokacija.grad;
        polje3.innerHTML = "Hotel: " + this.ponuda.lokacija.hotel;
        polje4.innerHTML = "Cena: " + this.ponuda.cena;

        let os = document.createElement("label");
        os.innerText = "Broj osoba:";
        os.classList.add("podaci");

        let numBrOS = document.createElement("input");
        numBrOS.setAttribute("disabled","true");
        numBrOS.type = "number";
        numBrOS.value = this.brojOsoba;

        let da = document.createElement("label");
        da.innerText = "Broj dana:";
        da.classList.add("podaci");

        let numBrDana = document.createElement("input");
        numBrDana.setAttribute("disabled","true");
        numBrDana.type = "number";
        numBrDana.value = this.brojDana;

        
        let izmeni = document.createElement("button");
        izmeni.innerText = "Izmeni";
        izmeni.classList.add("izmeniBtn");

        izmeni.onclick = () =>{
            if(izmeni.innerText == "Izmeni"){
                izmeni.innerText = "Potrvrdi";
                numBrDana.disabled = false;
                numBrOS.disabled = false;
            }else{
                fetch("https://localhost:5001/api/Rezervacija?ID="+this.id+"&brojDana="+numBrDana.value+"&brojOsoba="+numBrOS.value,
                {method:'PUT'})
                .then(res =>{
                    if(res.status == 200){
                        alert("Uspešno izmenjena rezervacija !");
                    }else{
                        alert("Greška pri izmeni rezervacije !");
                    }
                    numBrOS.disabled = true;
                    numBrDana.disabled = true;
                    izmeni.innerText = "Izmeni";
                })
                .catch(err => console.log(err));
            }
        }

        let obrisi = document.createElement("button");
        obrisi.innerText = "Obriši";
        obrisi.classList.add("obrisiBtn");

        obrisi.onclick =() =>{
            fetch("https://localhost:5001/api/Rezervacija?ID="+this.id,{method:'DELETE'})
                .then(res =>{
                    if(res.status == 200){
                        alert("Uspešno obrisana rezervacija !");
                    }else{
                        alert("Greška pri brisanju rezervacije !");
                    }
                    
                })
                container.removeChild(row);
        }

        row.appendChild(polje1);
        row.appendChild(polje2);
        row.appendChild(polje3);
        row.appendChild(polje4);
        row.appendChild(os);
        row.appendChild(numBrOS);
        row.appendChild(da); 
        row.appendChild(numBrDana);
        row.appendChild(izmeni);
        row.appendChild(obrisi);

        container.appendChild(row);
    }

    addToDatabase(){
        fetch("https://localhost:5001/api/Rezervacija?JMBG="+this.klijent.jmbg+"&IDponude="+this.ponuda.id+"&brojOsoba="+this.brojOsoba+"&brojDana="+this.brojDana, 
        {method: 'POST'})
            .then(res => {
                if(res.status == 200){
                    alert("Uspesno ste rezervisali putovanje, hvala !");
                }else{
                    alert("Greska pri rezervaciji !");
                }
                
            })
            .catch(err => console.log(err));        
    }
}