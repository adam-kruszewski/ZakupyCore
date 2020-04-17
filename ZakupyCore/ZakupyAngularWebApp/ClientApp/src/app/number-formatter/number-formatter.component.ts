import { Component } from '@angular/core';

@Component({
  selector: 'app-number-formatter-cell',
  templateUrl: './number-formatter.component.html'
  //template: `
  //  <span *ngIf="params.value">{{params.value}}zł</span>
  //`
})
export class NumberFormatterComponent {
  params: any;

  agInit(params: any): void {
    this.params = params;
  }
}
