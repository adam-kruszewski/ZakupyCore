import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ZamowieniaService, DefinicjaGrupy, DefinicjaProduktu } from '../zamowienia.service';
import { GrupaProduktow, Produkt } from '../zamowienie-produkty/zamowienie-produkty.component';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

@Component({
  selector: 'app-zamowienie',
  templateUrl: './zamowienie.component.html',
  styleUrls: []
})

export class ZamowienieComponent implements OnInit {
  zamowienie;
  grupy: Observable<any[]>;

  constructor(
    private route: ActivatedRoute,
    private zamowieniaService: ZamowieniaService) {
  }

  dajGrupe(data: DefinicjaGrupy) {
    let grupa: GrupaProduktow;
    grupa = new GrupaProduktow();
    grupa.nazwa = data.nazwa;
    grupa.limit = data.limit;
    grupa.produkty = data.produkty.map(function (definicja: DefinicjaProduktu) : Produkt {
      let produkt = new Produkt();
      produkt.nazwa = definicja.nazwa;
      produkt.cena = definicja.cena;

      return produkt;
    });
    return grupa;
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      let zamowienieID: number = params.get('zamowienieID') as unknown as number;
      this.zamowieniaService.getZamowienieByID(zamowienieID).then(data => {
        this.zamowienie = { nazwa: data.nazwa, id: data.id, data_konca: data.dataKonca };
      });

      this.grupy =
        this.zamowieniaService.getGrupyProduktowByID(zamowienieID)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => this.dajGrupe(item))))
      .pipe();
    });
  }
}
