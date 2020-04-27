import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ZamowieniaService, GrupaProduktow, Produkt, DefinicjaZamowienia } from '../zamowienia.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { FileUploadComponent } from '../file-upload/file-upload.component';

//import { MatDatepickerModule, MatDatepicker } from '@angular/material/datepicker';

@Component({
  selector: 'app-zamowienie-form',
  templateUrl: './zamowienie-form.component.html',
  styleUrls: []
})

export class ZamowienieFormComponent implements OnInit {
  checkoutForm;

  fileToUpload: File = null;

  @ViewChild('file1', null) plik: FileUploadComponent;

  constructor(
    private zamowieniaService: ZamowieniaService,
    private formBuilder: FormBuilder,
    private http: HttpClient) {
    this.checkoutForm = this.formBuilder.group({
      nazwa: ['', Validators.required],
      data_konca: ['', Validators.required],
      file: ['']
    });
    //this.checkoutForm.setValue('a1');
  }

  handleFileInput(files: FileList) {
    window.alert("Handle file input");
    this.fileToUpload = files.item(0);

    const endpoint = '/api/Files';
    const formData: FormData = new FormData();
    formData.append('fileKey', this.fileToUpload, this.fileToUpload.name);
    //let a: Observable<any> =
    this.http.post(endpoint, formData).toPromise()
      .then((data) => {
        let a = data == null;
        window.alert('Odebrane');
      });
  }

  ngOnInit() {
    let a: number = 1;
  }

  onSubmit(customerData) {

    let definicja: DefinicjaZamowienia = new DefinicjaZamowienia();
    definicja.nazwa = customerData.nazwa;
    definicja.dataKonca = customerData.data_konca;

    this.zamowieniaService.dodajDefinicje(definicja).then(data => {
      if (data != null)
        this.checkoutForm.reset();
    });

    //window.alert('nazwa:' + customerData.nazwa + ', data: ' + customerData.data_konca);
    console.warn('Your order has been submitted', customerData);
  }

  onFileLoaded(data : any) {
    window.alert('A123');
  }
}
