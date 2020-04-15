import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ZamowieniaService } from '../zamowienia.service';

@Component({
  selector: 'app-zamowienie-produkty',
  templateUrl: './zamowienie-produkty.component.html',
  styleUrls: []
})

export class ZamowienieProduktyComponent implements OnInit {
  grupyProduktow: GrupaProduktow[];

  constructor(
    private route: ActivatedRoute,
    private zamowieniaService: ZamowieniaService) {
    this.grupyProduktow = [];
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
  }
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
  nazwa: string;
  cena: number;
}
