import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { NumberFormatterComponent } from './number-formatter/number-formatter.component';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ZamowieniaComponent } from './zamowienia/zamowienia.component';
import { ZamowienieComponent } from './zamowienie/zamowienie.component';
import { ZamowienieFormComponent } from './zamowienie-form/zamowienie-form.component';
import { ZamowienieProduktyComponent } from './zamowienie-produkty/zamowienie-produkty.component';
import { ListaProduktowComponent } from './lista-produktow/lista-produktow.component';
import { IloscFormatterComponent } from './ilosc-formatter/ilosc-formatter.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatDatepickerModule, MatNativeDateModule } from '@angular/material';
import { FileUploadComponent } from './file-upload/file-upload.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ZamowieniaComponent,
    ZamowienieComponent,
    ZamowienieFormComponent,
    ZamowienieProduktyComponent,
    ListaProduktowComponent,
    NumberFormatterComponent,
    IloscFormatterComponent,
    FileUploadComponent
  ],
  imports: [
    MatDatepickerModule, MatNativeDateModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AgGridModule.withComponents([NumberFormatterComponent, IloscFormatterComponent]),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'zamowienia', component: ZamowieniaComponent },
      { path: 'zamowienie-form', component: ZamowienieFormComponent },
      { path: 'zamowienie/:zamowienieID', component: ZamowienieComponent },
      { path: 'zamowienie-produkty/:zamowienieID', component: ZamowienieProduktyComponent }
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
