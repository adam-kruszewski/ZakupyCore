import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ZamowieniaService, GrupaProduktow, Produkt } from '../zamowienia.service';
import { AgGridAngular } from 'ag-grid-angular';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-zamowienie-produkty',
  templateUrl: './zamowienie-produkty.component.html',
  styleUrls: []
})

export class ZamowienieProduktyComponent implements OnInit {
  grupyProduktow: Observable<GrupaProduktow[]>;

  @ViewChild('agGrid', null) agGrid: AgGridAngular;

  constructor(
    private route: ActivatedRoute,
    private zamowieniaService: ZamowieniaService) {
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      let zamowienieID: number = params.get('zamowienieID') as unknown as number;

      this.grupyProduktow =
        this.zamowieniaService.getGrupyProduktowByID(zamowienieID);
    });
  }
}

