import { Agencija } from './Agencija.js';
import { ListaPonuda } from './ListaPonuda.js'
import { ListaRezervacija } from './ListaRezervacija.js';
import { Ponuda } from './Ponuda.js'

let ucitajProveru = (jmbg) =>{
    document.body.innerHTML = '';
    mainMenu();

    let container = document.createElement("div");
    container.classList.add("container");
    let listaRez = new ListaRezervacija(jmbg);
    listaRez.loadData();
    listaRez.draw(container);

    document.body.appendChild(container);
}

let mainMenu = () =>{

    let selectAgenciju = document.createElement("select");
    let klikAgenciju = document.createElement("button");
    let agencijaDiv = document.createElement("div");

    agencijaDiv.classList.add("agencijaDiv");
    selectAgenciju.classList.add("select");
    klikAgenciju.classList.add("klikSelect");

    let containerAgencija = document.createElement("div");
    klikAgenciju.innerText = "Izaberi !";

    let proveraDiv = document.createElement("div");
    proveraDiv.classList.add("proveraDiv");

    let proveraInput = document.createElement("input");
    proveraInput.type = "text";
    proveraInput.placeholder = "Unesite JMBG da biste videli vaše rezervacije";
    proveraInput.classList.add("pInput");

    let proveraButton = document.createElement("button");
    proveraButton.innerText = "Proveri !";
    proveraButton.classList.add("klikSelect");

    let op = document.createElement("option");
    op.innerText = "Izaberite agenciju";

    selectAgenciju.appendChild(op);

    fetch("https://localhost:5001/api/admin/Agencija")
    .then(res => res.json())
    .then(res => res.forEach(el => {
        let ag = document.createElement("option");
        ag.id = el.id;
        ag.value = el.id;
        ag.innerHTML = el.imeAgencije;
        selectAgenciju.appendChild(ag);
    }));

    klikAgenciju.onclick = () => { 
        document.body.innerHTML = '';
        mainMenu();
        let agencija = new Agencija(selectAgenciju.value);
        agencija.ucitajAgenciju();
    }

    proveraButton.onclick = () => { ucitajProveru(proveraInput.value);}

    containerAgencija.classList.add("container");
    agencijaDiv.appendChild(selectAgenciju);
    agencijaDiv.appendChild(klikAgenciju);
    containerAgencija.appendChild(agencijaDiv);

    proveraDiv.appendChild(proveraInput);
    proveraDiv.appendChild(proveraButton);
    containerAgencija.appendChild(proveraDiv);

    document.body.appendChild(containerAgencija);
}

document.body.onload
{
    mainMenu();
}