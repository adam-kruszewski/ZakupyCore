import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-zamowienia',
  templateUrl: './zamowienia.component.html',
  styleUrls: ['./zamowienia.component.css']
})

export class ZamowieniaComponent implements OnInit {
  zamowienia;
  numerZamowienia = 20;

  constructor() {
    this.numerZamowienia = 33;
  }

  onDodaj() {
    window.alert('Dodawanie nowego zamówienia');

    this.zamowienia.push({ nazwa: 'Nowe zamówienie ' + this.numerZamowienia, data_konca: new Date() });
    this.numerZamowienia++;
  }

  ngOnInit() {
    this.zamowienia =
      [
      { nazwa: 'zamowienie1', data_konca: new Date() },
      { nazwa: 'zamowienie2', data_konca: new Date() }
      ];
  }
}
