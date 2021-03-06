import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { NumberFormatterComponent } from '../number-formatter/number-formatter.component';
import { ZamowieniaService, Produkt, GrupaProduktow } from '../zamowienia.service';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { IloscFormatterComponent } from '../ilosc-formatter/ilosc-formatter.component';

@Component({
  selector: 'app-lista-produktow',
  templateUrl: './lista-produktow.component.html',
  styleUrls: []
})

export class ListaProduktowComponent implements OnInit {
  @Input() grupyProduktow: Observable<GrupaProduktow[]>;
  @Input() wyswietlacIlosc: boolean;
  @Input() edytowacIlosc: boolean;

  @ViewChild('agGrid', null) agGrid: AgGridAngular;

  frameworkComponents = {
    numberFormatterComponent: NumberFormatterComponent,
    iloscFormatterComponent: IloscFormatterComponent
  };

  columnDefs = [
    { headerName: 'Nazwa produktu/grupy', field: 'nazwa' },
    { headerName: 'Limit', field: 'limit' },
    { headerName: 'Cena', field: 'cena', cellRenderer: 'numberFormatterComponent' }];

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
    if (this.wyswietlacIlosc)
      if (this.edytowacIlosc) {
        this.columnDefs.push({ headerName: 'Ilość', field: 'ilosc', cellRenderer: 'iloscFormatterComponent' });
      } else {
        this.columnDefs.push({ headerName: 'Ilość', field: 'ilosc' });
      }

    this.wiersze =
      this.grupyProduktow.pipe<Wiersz[]>(
        map((data: GrupaProduktow[]) => this.przygotujWiersze(data)))
        .pipe();
    this.agGrid.rowStyle = "wiersz1";
  }

  przygotujWiersze(grupyProduktow: GrupaProduktow[]): Wiersz[] {
    let localWiersze = [];
    let edytowac = this.edytowacIlosc;

    grupyProduktow.forEach(
      function (g: GrupaProduktow) {
        let wiersz = new Wiersz();
        wiersz.wypelnijDlaGrupy(g);
        localWiersze.push(wiersz);

        g.produkty.forEach(
          function (p: Produkt) {
            let wiersz = new Wiersz();
            wiersz.wypelniejDlaProduktu(p, edytowac);
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

    let edytowac = this.edytowacIlosc;

    grupa.produkty.forEach(function (p: Produkt) {
      let wierszProduktu: Wiersz;
      wierszProduktu = new Wiersz();
      wierszProduktu.wypelniejDlaProduktu(p, edytowac);
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
  produkt_id: number;
  edytowac: boolean;

  wypelnijDlaGrupy(grupa: GrupaProduktow) {
    this.grupa = true;
    this.nazwa = grupa.nazwa;
    this.limit = grupa.limit;
    this.edytowac = false;
  }

  wypelniejDlaProduktu(produkt: Produkt, edytowac: boolean) {
    this.grupa = false;
    this.produkt_id = produkt.id;
    this.nazwa = produkt.nazwa;
    this.cena = produkt.cena;
    this.edytowac = edytowac;
  }
}
