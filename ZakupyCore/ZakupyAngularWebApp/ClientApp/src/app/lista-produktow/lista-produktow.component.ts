import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { NumberFormatterComponent } from '../number-formatter/number-formatter.component';
import { Produkt, GrupaProduktow } from '../zamowienie-produkty/zamowienie-produkty.component';
import { ZamowieniaService, DefinicjaGrupy, DefinicjaProduktu } from '../zamowienia.service';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

@Component({
  selector: 'app-lista-produktow',
  templateUrl: './lista-produktow.component.html',
  styleUrls: []
})

export class ListaProduktowComponent implements OnInit {
  @Input() grupyProduktow: Observable<GrupaProduktow[]>;

  @ViewChild('agGrid', null) agGrid: AgGridAngular;

  frameworkComponents = {
    numberFormatterComponent: NumberFormatterComponent,
  };

  columnDefs = [
    { headerName: 'Nazwa produktu/grupy', field: 'nazwa' },
    { headerName: 'Limit', field: 'limit' },
    { headerName: 'Cena', field: 'cena', cellRenderer: 'numberFormatterComponent' },
    { headerName: 'Ilość', field: 'ilosc' }
  ];

  wiersze: Observable<Wiersz[]>;

  constructor() {
  }

  getRowStyleScheduled(data) {
    if (data.data.grupa)
      return "wiersz-grupy";
    else
      return "wiersz-produktu";
  }

  ngOnInit() {
    this.wiersze =
      this.grupyProduktow.pipe<Wiersz[]>(
        map((data: GrupaProduktow[]) => this.przygotujWiersze(data)))
        .pipe();
    this.agGrid.rowStyle = "wiersz1";
  }

  przygotujWiersze(grupyProduktow: GrupaProduktow[]): Wiersz[] {
    let localWiersze = [];
    grupyProduktow.forEach(
      function (g: GrupaProduktow) {
        let wiersz = new Wiersz();
        wiersz.wypelnijDlaGrupy(g);
        localWiersze.push(wiersz);

        g.produkty.forEach(
          function (p: Produkt) {
            let wiersz = new Wiersz();
            wiersz.wypelniejDlaProduktu(p);
            localWiersze.push(wiersz);
          });
      });

    return localWiersze;
  }

  dodajWiersze(grupa: GrupaProduktow, wiersze: Wiersz[]) {
    let wiersz: Wiersz;
    wiersz = new Wiersz();
    wiersz.wypelnijDlaGrupy(grupa);
    wiersze.push(wiersz);

    grupa.produkty.forEach(function (p: Produkt) {
      let wierszProduktu: Wiersz;
      wierszProduktu = new Wiersz();
      wierszProduktu.wypelniejDlaProduktu(p);
      wiersze.push(wierszProduktu);
    });
  }
}

class Wiersz {
  nazwa: string;
  limit: number;
  cena: number;
  ilosc: number;
  grupa: boolean;

  wypelnijDlaGrupy(grupa: GrupaProduktow) {
    this.grupa = true;
    this.nazwa = grupa.nazwa;
    this.limit = grupa.limit;
  }

  wypelniejDlaProduktu(produkt: Produkt) {
    this.grupa = false;
    this.nazwa = produkt.nazwa;
    this.cena = produkt.cena;
  }
}
