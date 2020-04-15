import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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

  constructor(private http: HttpClient) {
  }
}

export class DefinicjaZamowienia {
  id: number;
  nazwa: string;
  dataKonca: Date;
}
