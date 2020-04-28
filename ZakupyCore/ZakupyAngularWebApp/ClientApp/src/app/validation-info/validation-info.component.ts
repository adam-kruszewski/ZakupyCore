import { Component, OnInit, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-validation-info',
  templateUrl: './validation-info.component.html',
  styleUrls: []
})
export class ValidationInfoComponent implements OnInit {

  @Input() control: any;
  @Input() controlLabel: string;
  @Input() validationErrorsFunctions: ValidationError[] = []

  constructor() { }

  ngOnInit() {
    console.log('Liczba funkcji walidatorów: ' + this.validationErrorsFunctions.length);
  }

}

export class ValidationError {
  text: string;
  checkDisplayFunction: (control: AbstractControl) => boolean;

  constructor(
    text: string,
    checkDisplayFunction: (AbstractControl) => boolean) {
    this.text = text;
    this.checkDisplayFunction = checkDisplayFunction;
  }
}
