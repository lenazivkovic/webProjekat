export class Klijent{

    id;
    ime;
    prezime;
    jmbg;
    grad;
    adresa;
    telefon;

    constructor(id="",ime="",prezime="",jmbg="",grad="",adresa="",telefon=""){
        this.id = id;
        this.ime = ime;
        this.prezime = prezime;
        this.jmbg = jmbg;
        this.grad = grad;
        this.adresa = adresa;
        this.telefon = telefon;
    }

    async getFromDatabaseAsync(jmbg){

        var y = await fetch("https://localhost:5001/api/Klijent?JMBG="+jmbg);
        var x = await y.json();

        this.id = x.id;
        this.ime = x.imeKlijenta;
        this.prezime = x.prezimeKlijenta;
        this.jmbg = x.jmbg;
        this.grad = x.grad;
        this.adresa = x.adresa;
        this.telefon = x.kontaktTelefon;
    }

    getFromDatabase(jmbg){

        var request = new XMLHttpRequest();
        request.open('GET',"https://localhost:5001/api/Klijent?JMBG="+jmbg, false);  // `false` makes the request synchronous
        
        request.send(null);
        
        let data = JSON.parse(request.response);
        this.id = data.id;
        this.ime = data.imeKlijenta;
        this.prezime = data.prezimeKlijenta;
        this.grad = data.grad;
        this.jmbg = data.jmbg;
        this.adresa = data.adresa;
    }

    addToDatabase(){
        let data = {
            "imeKlijenta": this.ime,
            "prezimeKlijenta": this.prezime,
            "jmbg": this.jmbg,
            "grad": this.grad,
            "adresa": this.adresa,
            "kontaktTelefon": this.telefon
        }

        var request = new XMLHttpRequest();
        request.open('POST',"https://localhost:5001/api/Klijent", false);  // `false` makes the request synchronous
        request.setRequestHeader('Content-Type', 'application/json');
        request.send(JSON.stringify(data));
        
    }

    async addToDatabaseAsync(){
        let data = {
            "imeKlijenta": this.ime,
            "prezimeKlijenta": this.prezime,
            "jmbg": this.jmbg,
            "grad": this.grad,
            "adresa": this.adresa,
            "kontaktTelefon": this.telefon
        }

        fetch("https://localhost:5001/api/Klijent", {
            method: "POST",
            headers: {'Content-Type': 'application/json'}, 
            body: JSON.stringify(data)
          }).then(res => {
              if(res.status == 200){
                console.log(res);
              }else{
                alert("Neispravno uneti podaci o klijentu !");
              }
          });
    }

    removeFromDatabase(){
        fetch("https://localhost:5001/api/Klijent?ID="+this.id,{method:'DELETE'})
        .then(res => console.log(res));
    }
}