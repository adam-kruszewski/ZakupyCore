import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GrupaProduktow, Produkt } from '../zamowienia.service';
import { AgGridAngular } from 'ag-grid-angular';
import { NumberFormatterComponent } from '../number-formatter/number-formatter.component';

@Component({
  selector: 'app-zamowienie-produkty',
  templateUrl: './zamowienie-produkty.component.html',
  styleUrls: []
})

export class ZamowienieProduktyComponent implements OnInit {
  grupyProduktow: GrupaProduktow[];

  @ViewChild('agGrid', null) agGrid: AgGridAngular;

  frameworkComponents = {
    numberFormatterComponent: NumberFormatterComponent,
  };

  columnDefs = [
    { headerName: 'Nazwa produktu/grupy', field: 'nazwa' },
    { headerName: 'Cena', field: 'cena', cellRenderer: 'numberFormatterComponent' },
    { headerName: 'Ilość / limit', field: 'limit' }
  ];

  rowData = [];

  constructor(
    private route: ActivatedRoute) {
    this.grupyProduktow = [];
  }

  getRowStyleScheduled(data) {
    if (data.data.grupa)
      return "wiersz-grupy";
    else
      return "wiersz-produktu";
  }

  ngOnInit() {
    let grupa1: GrupaProduktow;

    grupa1 = new GrupaProduktow();
    grupa1.nazwa = "Grupa bez limitu";
    grupa1.limit = 0;
    grupa1.produkty.push({ nazwa: "Produkt pierwszy", cena: 1.56 });

    let grupa2: GrupaProduktow;
    grupa2 = new GrupaProduktow();
    grupa2.nazwa = 'Grupa z limitem';
    grupa2.limit = 5;
    grupa2.produkty.push({
      nazwa: 'Produkt drugi', cena: 2.34
    });
    grupa2.produkty.push({
      nazwa: 'Produkt trzeci', cena: 2.34
    });

    grupa2.produkty.push({
      nazwa: 'Produkt czwarty', cena: 2.34
    });

    this.grupyProduktow.push(grupa1);
    this.grupyProduktow.push(grupa2);
    //this.route.paramMap.subscribe(params => {
    //  let zamowienieID: number = params.get('zamowienieID') as unknown as number;
    //  this.zamowieniaService.getZamowienieByID(zamowienieID).then(data => {
    //    this.zamowienie = { nazwa: data.nazwa, id: data.id, data_konca: data.dataKonca };
    //  });
    //});

    let wiersze = [];
    this.grupyProduktow.forEach(function (grupa: GrupaProduktow) {
      wiersze.push({
        nazwa: grupa.nazwa, limit: grupa.limit, grupa: true
      });

      grupa.produkty.forEach(function (produkt: Produkt) {
        wiersze.push({
          nazwa: produkt.nazwa, cena: produkt.cena, grupa: false
        });
      });
    });

    for (let i = 0; i < wiersze.length; i++)
      this.rowData.push(wiersze[i]);

    this.agGrid.rowStyle = "wiersz1";
  }
}

