import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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

  getGrupyProduktowByID(id: number): Observable<DefinicjaGrupy[]> {
    return this.http.get<DefinicjaGrupy[]>('/api/ProduktyZamowienia?zamowienieID=' + id);
  }

  constructor(private http: HttpClient) {
  }
}

export class DefinicjaZamowienia {
  id: number;
  nazwa: string;
  dataKonca: Date;
}

export class DefinicjaProduktu {
  nazwa: string;
  cena: number;
}

export class DefinicjaGrupy {
  nazwa: string;
  limit: number;

  produkty: DefinicjaProduktu[]
}
