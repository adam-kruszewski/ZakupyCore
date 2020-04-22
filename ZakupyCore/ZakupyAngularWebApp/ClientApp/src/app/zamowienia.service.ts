import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})

export class ZamowieniaService {
  getZamowienia() {
    let zamowienia =
      this.http.get<DefinicjaZamowienia>('/api/zamowienia');

    return zamowienia;
  }

  getZamowienieByID(id: number): Promise<any> {
    return this.http.get('/api/zamowienie?id=' + id).toPromise();
  }

  getGrupyProduktowByID(id: number): Observable<GrupaProduktow[]> {
    return this.http.get<DefinicjaGrupy[]>('/api/ProduktyZamowienia?zamowienieID=' + id)
      .pipe<GrupaProduktow[]>(
        map((data: DefinicjaGrupy[]) =>
          data.map((item: DefinicjaGrupy) => this.dajGrupe(item))
        ));
  }

  dodajDefinicje(definicja: DefinicjaZamowienia): Promise<number | null> {
    //: Promise<number | null> {
    var definicjaRequest = new DodawanieZamowowieniaRequest();
    definicjaRequest.nazwa = definicja.nazwa;
    definicjaRequest.dataKoncaZamawiania = definicja.dataKonca;

    return this.http.put('api/zamowienie', definicjaRequest)
      .toPromise()
      .then<number | any>(
        (data: any) => {
          let wynik: number | null;

          if (data.sukces)
            wynik = data.id;
          else
            wynik = null;

          return Promise.resolve<number | null>(wynik);
        });
  }

  private dajGrupe(data: DefinicjaGrupy): GrupaProduktow {
    let grupa: GrupaProduktow;
    grupa = new GrupaProduktow();
    grupa.nazwa = data.nazwa;
    grupa.limit = data.limit;
    grupa.produkty = data.produkty.map(function (definicja: DefinicjaProduktu): Produkt {
      let produkt = new Produkt();
      produkt.nazwa = definicja.nazwa;
      produkt.cena = definicja.cena;
      produkt.id = definicja.id;

      return produkt;
    });
    return grupa;
  }

  constructor(private http: HttpClient) {
  }
}

export class DefinicjaZamowienia {
  id: number;
  nazwa: string;
  dataKonca: Date;
}

class DefinicjaProduktu {
  id: number;
  nazwa: string;
  cena: number;
}

class DefinicjaGrupy {
  nazwa: string;
  limit: number;

  produkty: DefinicjaProduktu[]
}

class DodawanieZamowowieniaRequest {
  nazwa: string;

  dataKoncaZamawiania: Date;
}

export class GrupaProduktow {
  nazwa: string;
  limit: number;

  produkty: Produkt[];

  constructor() {
    this.produkty = [];
  }
}

export class Produkt {
  id: number;
  nazwa: string;
  cena: number;
}
