import { Component, OnInit } from '@angular/core';
import { ZamowieniaService } from '../zamowienia.service';

@Component({
  selector: 'app-zamowienia',
  templateUrl: './zamowienia.component.html',
  styleUrls: ['./zamowienia.component.css']
})

export class ZamowieniaComponent implements OnInit {
  zamowienia;
  numerZamowienia = 20;

  constructor(private zamowieniaService: ZamowieniaService) {
    this.numerZamowienia = 33;
  }

  onDodaj() {
    window.alert('Dodawanie nowego zamówienia');

    this.zamowienia = this.zamowieniaService.getZamowienia();

    //this.zamowienia.push({ nazwa: 'Nowe zamówienie ' + this.numerZamowienia, data_konca: new Date() });
    //this.numerZamowienia++;
  }

  ngOnInit() {
    this.zamowienia =
      [
      { nazwa: 'zamowienie1', data_konca: new Date() },
      { nazwa: 'zamowienie2', data_konca: new Date() }
      ];

    this.zamowienia = this.zamowieniaService.getZamowienia();
  }
}
