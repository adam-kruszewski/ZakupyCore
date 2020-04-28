import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, ValidatorFn, AbstractControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { ZamowieniaService, DefinicjaZamowienia } from '../zamowienia.service';
import { HttpClient } from '@angular/common/http';
import { FileUploadComponent } from '../file-upload/file-upload.component';
import { ValidationError } from '../validation-info/validation-info.component';

@Component({
  selector: 'app-zamowienie-form',
  templateUrl: './zamowienie-form.component.html',
  styleUrls: []
})

export class ZamowienieFormComponent implements OnInit {
  checkoutForm;

  dataKoncaValidationErrors: ValidationError[];

  @ViewChild('file1', null) plik: FileUploadComponent;

  constructor(
    private zamowieniaService: ZamowieniaService,
    private formBuilder: FormBuilder) {
    this.checkoutForm = this.formBuilder.group({
      nazwa: ['', Validators.required],
      data_konca: ['', [Validators.required, dataNieZPrzeszlosci()]],
      file: ['']
    });

    this.dataKoncaValidationErrors =
      [
        new ValidationError('Data nie może być wcześniejsza niż dzisiejsza', function (control: AbstractControl) {
          return control.errors.dataZPrzeszlosci;
        })
      ];
  }

  ngOnInit() {
  }

  onSubmit(customerData) {

    let definicja: DefinicjaZamowienia = new DefinicjaZamowienia();
    definicja.nazwa = customerData.nazwa;
    definicja.dataKonca = customerData.data_konca;

    this.zamowieniaService.dodajDefinicje(definicja).then(data => {
      if (data != null)
        this.checkoutForm.reset();
    });

    console.warn('Your order has been submitted', customerData);
  }
}

export function dataNieZPrzeszlosci(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    let forbidden = false;
    let value: Date = control.value as Date;

    let dzis = new Date(new Date().toDateString());

    if (control.value != '' && value != null && value < dzis)
      forbidden = true;

    return forbidden ? { 'dataZPrzeszlosci': { value: control.value } } : null;
  };
}
