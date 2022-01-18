import { ListaPonuda } from './ListaPonuda.js'
import { ListaRezervacija } from './ListaRezervacija.js';
import { Ponuda } from './Ponuda.js'

let ucitajAgenciju = (idAgencije) =>{
    document.body.innerHTML = "";
    mainMenu();

    if(idAgencije == "Izaberite agenciju")
        return;
        
    let container = document.createElement("div");
    let divPonude = document.createElement("div");
    let rezForma = document.createElement("div");
    rezForma.classList.add("rezForma");

    divPonude.setAttribute("class","ponude");

    let filtriranje = document.createElement("div");
    filtriranje.classList.add("filter");
    filtriranje.classList.add("border");
    
    let agencijaIme= document.createElement("h4");
    agencijaIme.classList.add("imeAgencije");

    let email = document.createElement("p");
    email.classList.add("krajForme");
    let adr = document.createElement("p");
    adr.classList.add("krajForme");

    fetch("https://localhost:5001/api/admin/Agencija?idAgencije="+idAgencije)
    .then(p => p.json())
    .then(p => {
        agencijaIme.innerText = p.imeAgencije;
        email.innerHTML = "Email: " + p.email;
        adr.innerHTML = "Adresa: "+ p.adresa;
    })

    filtriranje.appendChild(agencijaIme);

    let drzavaLabel = document.createElement("label");
    drzavaLabel.setAttribute("for","drzava");
    drzavaLabel.innerHTML = "Država:";
    filtriranje.appendChild(drzavaLabel);

    let drzava = document.createElement("select");
    let temp = document.createElement("option");
    temp.innerText = "-";
    drzava.appendChild(temp);

    drzava.classList.add("drzavaIzbor");

    fetch("https://localhost:5001/api/Lokacija/Drzave")
    .then(p => p.json())
    .then(p => p.forEach(el => {
        let opcija = document.createElement("option");
        opcija.innerHTML = el;
        opcija.value = el;
       drzava.appendChild(opcija);
    }));

    filtriranje.appendChild(drzava);

    let gradLabel = document.createElement("label");
    gradLabel.setAttribute("for","grad");
    gradLabel.innerHTML = "Grad:";
    filtriranje.appendChild(gradLabel);

    let grad = document.createElement("select");
    grad.classList.add("gradIzbor");
    filtriranje.appendChild(grad);

    let datumMaxInput = document.createElement("input");
    datumMaxInput.setAttribute("type","date");
    datumMaxInput.setAttribute("name","datum");
    datumMaxInput.classList.add("datum");
    
    let datumMinInput = document.createElement("input");
    datumMinInput.setAttribute("type","date");
    datumMinInput.setAttribute("name","datum");
    datumMinInput.classList.add("datum");

    var today = new Date();

      var dd = today.getDate();
      var mm = today.getMonth()+1;
      var yyyy = today.getFullYear();

      if(dd<10) {dd = '0'+dd} 
      if(mm<10) {mm = '0'+mm} 
    
      today = yyyy + '-' + mm + '-' + dd;

    let datminLbl = document.createElement("label");
    datminLbl.innerText = "Najraniji polazak:";
    datminLbl.setAttribute("for","datumMinInput");
    

    let datmaxLbl = document.createElement("label");
    datmaxLbl.innerText = "Najkasniji polazak:";
    datmaxLbl.setAttribute("for","datumMaxInput");

    datumMaxInput.value = today;
    datumMinInput.value = today;
    filtriranje.appendChild(datminLbl);
    filtriranje.appendChild(datumMinInput);
    filtriranje.appendChild(datmaxLbl);
    filtriranje.appendChild(datumMaxInput);

    let minLabel = document.createElement("label");
    minLabel.setAttribute("for","minCena");
    minLabel.innerHTML = "Minimalna cena";
    filtriranje.appendChild(minLabel);

    let minCInput = document.createElement("input");
    minCInput.setAttribute("type","number");
    minCInput.setAttribute("value","0");
    minCInput.setAttribute("name","minCena");
    minCInput.classList.add("minCena");
    filtriranje.appendChild(minCInput);
    
    let maxLabel = document.createElement("label");
    maxLabel.setAttribute("for","maxCena");
    maxLabel.innerHTML = "Maksimalna cena";
    filtriranje.appendChild(maxLabel);

    let maxCInput = document.createElement("input");
    maxCInput.setAttribute("type","number");
    maxCInput.setAttribute("value","0");
    maxCInput.setAttribute("name","maxCena");
    maxCInput.classList.add("maxCena");
    filtriranje.appendChild(maxCInput);

    let klik = document.createElement("button");
    klik.classList.add("klikSelect");

    klik.onclick = () =>{
        divPonude.innerHTML = '';
        let dat = document.querySelector(".datum").value;
        let minC = document.querySelector(".minCena").value;
        let maxC = document.querySelector(".maxCena").value;
        let grad = document.querySelector(".gradIzbor").value;
    
        let listaPonuda = new ListaPonuda(idAgencije,grad,minC,maxC,datumMinInput.value,datumMaxInput.value);

        listaPonuda.draw(divPonude);
        
    }
    klik.innerHTML = "Pretraži !";
    filtriranje.appendChild(klik);

    filtriranje.appendChild(email);    
    filtriranje.appendChild(adr); 

    container.appendChild(filtriranje);
    container.appendChild(divPonude);
    container.classList.add("container");
    

    document.body.appendChild(container);
    grad.innerHTML = '';

    fetch("https://localhost:5001/api/Lokacija/Gradovi?drzava="+drzava.value)
        .then(p => p.json())
        .then(p => p.forEach(el => {
            let opcija = document.createElement("option");
            opcija.innerHTML = el;
            opcija.value = el;
            grad.appendChild(opcija);
        }))

    document.body.appendChild(rezForma);
    drzava.onchange = () =>{

        grad.innerHTML = '';
    
        fetch("https://localhost:5001/api/Lokacija/Gradovi?drzava="+drzava.value)
            .then(p => p.json())
            .then(p => p.forEach(el => {
                let opcija = document.createElement("option");
                opcija.innerHTML = el;
                opcija.value = el;
                grad.appendChild(opcija);
            }))
        
    }
}

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
    proveraInput.style = "height:50px;width:100%;";

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

    klikAgenciju.onclick = () => { ucitajAgenciju(selectAgenciju.value);}

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