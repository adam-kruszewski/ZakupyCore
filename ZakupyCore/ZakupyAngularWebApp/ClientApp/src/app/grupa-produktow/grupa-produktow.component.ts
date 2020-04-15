import { Component, OnInit, Input } from '@angular/core';
import { GrupaProduktow } from '../zamowienie-produkty/zamowienie-produkty.component';

@Component({
  selector: 'app-grupa-produktow',
  templateUrl: './grupa-produktow.component.html',
  styleUrls: []
})

export class GrupaProduktowComponent {
  @Input() grupaProduktow: GrupaProduktow;

  constructor() {
  }
}
