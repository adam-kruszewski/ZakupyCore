import { Component, OnInit } from '@angular/core';
import { ZamowieniaService, DefinicjaZamowienia } from '../zamowienia.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-zamowienia',
  templateUrl: './zamowienia.component.html',
  styleUrls: ['./zamowienia.component.css']
})

export class ZamowieniaComponent implements OnInit {
  zamowienia: Observable<DefinicjaZamowienia>;
  numerZamowienia = 20;

  constructor(private zamowieniaService: ZamowieniaService) {
    this.numerZamowienia = 33;
  }

  onDodaj() {
    window.alert('Dodawanie nowego zamówienia');

    this.zamowienia = this.zamowieniaService.getZamowienia();
  }

  ngOnInit() {
    this.zamowienia = this.zamowieniaService.getZamowienia();
  }
}
