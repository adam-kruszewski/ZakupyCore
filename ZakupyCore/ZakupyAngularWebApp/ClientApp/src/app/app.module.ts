import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
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
import { ZamowienieProduktyComponent } from './zamowienie-produkty/zamowienie-produkty.component';
import { ListaProduktowComponent } from './lista-produktow/lista-produktow.component';
import { IloscFormatterComponent } from './ilosc-formatter/ilosc-formatter.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ZamowieniaComponent,
    ZamowienieComponent,
    ZamowienieProduktyComponent,
    ListaProduktowComponent,
    NumberFormatterComponent,
    IloscFormatterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AgGridModule.withComponents([NumberFormatterComponent, IloscFormatterComponent]),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'zamowienia', component: ZamowieniaComponent },
      { path: 'zamowienie/:zamowienieID', component: ZamowienieComponent },
      { path: 'zamowienie-produkty/:zamowienieID', component: ZamowienieProduktyComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
