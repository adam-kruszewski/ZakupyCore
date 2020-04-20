import { Component } from '@angular/core';

@Component({
  selector: 'app-ilosc-formatter-cell',
  templateUrl: './ilosc-formatter.component.html'
  //template: `
  //  <span *ngIf="params.value">{{params.value}}zł</span>
  //`
})
export class IloscFormatterComponent {
  params: any;

  agInit(params: any): void {
    this.params = params;
  }
}
