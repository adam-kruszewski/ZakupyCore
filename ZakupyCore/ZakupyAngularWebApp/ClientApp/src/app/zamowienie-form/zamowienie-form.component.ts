import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ZamowieniaService, GrupaProduktow, Produkt } from '../zamowienia.service';

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
      nazwa: '',
      data_konca: ''
    });
  }

  ngOnInit() {
  }

  onSubmit(customerData) {
    this.checkoutForm.reset();

    console.warn('Your order has been submitted', customerData);
  }
}
