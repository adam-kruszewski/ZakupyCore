import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ZamowieniaService } from '../zamowienia.service';

@Component({
  selector: 'app-zamowienie',
  templateUrl: './zamowienie.component.html',
  styleUrls: []
})

export class ZamowienieComponent implements OnInit {
  zamowienie;

  constructor(
    private route: ActivatedRoute,
    private zamowieniaService: ZamowieniaService) {
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      let zamowienieID: number = params.get('zamowienieID') as unknown as number;
      this.zamowieniaService.getZamowienieByID(zamowienieID).then(data => {
        this.zamowienie = { nazwa: data.nazwa, id: data.id, data_konca: data.dataKonca };
      });
    });
  }
}
