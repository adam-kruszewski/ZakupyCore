import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class ZamowieniaService {
  getZamowienia() {
    let zamowienia =
      this.http.get('/api/zamowienia');

    return zamowienia;
  }

  constructor(private http: HttpClient) {
  }
}
