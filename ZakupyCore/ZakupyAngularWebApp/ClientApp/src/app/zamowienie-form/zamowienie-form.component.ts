import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ZamowieniaService, GrupaProduktow, Produkt } from '../zamowienia.service';
//import { MatDatepickerModule, MatDatepicker } from '@angular/material/datepicker';

@Component({
  selector: 'app-zamowienie-form',
  templateUrl: './zamowienie-form.component.html',
  styleUrls: []
})

export class ZamowienieFormComponent implements OnInit {
  checkoutForm;

  constructor(
    private zamowieniaService: ZamowieniaService,
    private formBuilder: FormBuilder) {
    this.checkoutForm = this.formBuilder.group({
      nazwa: ['', Validators.required],
      data_konca: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  onSubmit(customerData) {
    this.checkoutForm.reset();

    window.alert('nazwa:' + customerData.nazwa + ', data: ' + customerData.data_konca);
    console.warn('Your order has been submitted', customerData);
  }
}