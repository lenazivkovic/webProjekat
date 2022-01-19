import { Klijent } from "./Klijent.js";
import { Lokacija } from "./Lokacija.js";
import { Rezervacija } from "./Rezervacija.js";

export class Ponuda {
    
    constructor(id,lokacija,cena,datum,slika){
        this.id = id;
        this.lokacija = lokacija;
        this.cena = cena;
        this.datum = datum;
        this.slika = slika;
    }

    async getFromDatabaseAsync(id){
        await fetch("https://localhost:5001/api/Ponuda?ID="+id)
        .then(res => res.json())
        .then(res => {
            this.id = res.id;
            this.lokacija = res.lokacija;
            this.cena = res.cena;
            this.datum = res.datum;
        })
        .catch(err => alert(err));
    }

    draw(container){
            let row = document.createElement("div");
            row.classList.add("box");
            row.classList.add("border");
            let slika = document.createElement("img");
            let polje1 = document.createElement("h4");
            let polje2 = document.createElement("h5");
            let polje3 = document.createElement("h5");

            slika.src = this.slika; 
            slika.alt = "Nema slike !";
            polje1.innerText = "Lokacija : " +this.lokacija.drzava + " - " + this.lokacija.grad;
            polje3.innerText = "Hotel : "+ this.lokacija.hotel;
            polje2.innerText = "Cena po osobi : " + this.cena;
            
            
            let button = document.createElement("button");

            button.innerText = "Rezerviši";

            button.onclick = () =>{
                let container = document.querySelectorAll(".container").item(1);
                container.innerHTML='';
                let rezForma = document.querySelector(".rezForma");
                rezForma.classList.add("border"); 
                rezForma.style = "background-color: whitesmoke;"
                rezForma.innerHTML = '';

                let brojDanaP = document.createElement("input");
                brojDanaP.type = "number";
                let brojOsobaP = document.createElement("input");
                brojOsobaP.type = "number";

                brojOsobaP.placeholder = "Unesite broj osoba";
                brojDanaP.placeholder = "Unesite broj dana";

                let jmbgPostojeci = document.createElement("input");
                jmbgPostojeci.type = "text";
                jmbgPostojeci.placeholder = "Unesite Vaš JMBG za novu rezervaciju!";
                
                let postojeciLabel = document.createElement("label");
                postojeciLabel.innerHTML = "Postojeći korisnik: ";

                let klijentPostoji = document.createElement("button");
                klijentPostoji.innerText = "Rezerviši!";

                klijentPostoji.onclick = () =>{
                    let k = new Klijent();
                    k.getFromDatabase(jmbgPostojeci.value);
                    let rez = new Rezervacija(0,k,this,brojDanaP.value,brojOsobaP.value);
                    rez.addToDatabase();
                    document.body.removeChild(rezForma);
                }

                let noviLabel = document.createElement("label");    
                noviLabel.innerHTML = "Novi korisnik: ";

                let noviKlijent = document.createElement("button");

                let ime = document.createElement("input");
                ime.type="text";
                ime.placeholder="Ime";

                let prezime = document.createElement("input");
                prezime.type="text";
                prezime.placeholder = "Prezime";

                let grad = document.createElement("input");
                grad.type="text";
                grad.placeholder ="Grad u kome zivite";

                let adresa = document.createElement("input");
                adresa.type="text";
                adresa.placeholder = "Adresu stanovanja.";

                let telefon = document.createElement("input");
                telefon.type="text";
                telefon.placeholder = "Kontakt telefon";

                let jmbg = document.createElement("input");
                jmbg.type="text";
                jmbg.placeholder = "JMBG";

                let brojDanaN = document.createElement("input");
                brojDanaN.type = "number";
                let brojOsobaN = document.createElement("input");
                brojOsobaN.type = "number";

                brojOsobaN.placeholder = "Unesite broj osoba";
                brojDanaN.placeholder = "Unesite broj dana";

                noviKlijent.innerText = "Rezerviši!";   

                noviKlijent.onclick = async () =>{
                    let temp = new Klijent();
                    temp.getFromDatabase(jmbg.value);
                    if(temp.id != undefined){
                        alert("Vec postojite u bazi, popunite deo za postojece klijente!");
                    }
                    else{
                        let k = new Klijent(0,ime.value,prezime.value,jmbg.value,grad.value,adresa.value,telefon.value);
                        k.addToDatabase();
                        let rez = new Rezervacija(0,k,this,brojDanaN.value,brojOsobaN.value);
                        rez.addToDatabase(k.jmbg,this.id);
                        document.body.removeChild(rezForma);
                    }
                    
                }

                rezForma.appendChild(postojeciLabel);
                rezForma.appendChild(jmbgPostojeci);
                rezForma.appendChild(brojDanaP);
                rezForma.appendChild(brojOsobaP);
                rezForma.appendChild(klijentPostoji);
                rezForma.appendChild(noviLabel);
                rezForma.appendChild(ime);
                rezForma.appendChild(prezime);
                rezForma.appendChild(grad);
                rezForma.appendChild(adresa);
                rezForma.appendChild(jmbg);
                rezForma.appendChild(telefon);
                rezForma.appendChild(brojDanaN);
                rezForma.appendChild(brojOsobaN);
                rezForma.appendChild(noviKlijent);
            }
            row.appendChild(slika);
            row.appendChild(polje1);
            row.appendChild(polje3);
            row.appendChild(polje2);
            row.appendChild(button);
            
            container.appendChild(row);
    }
}