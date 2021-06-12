import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AspiranteRegistroComponent } from './aspirante/aspirante-registro/aspirante-registro.component';
import { AppRoutingModule } from './app-routing.module';
import { EmpresaRegistroComponent } from './empresa/empresa-registro/empresa-registro.component';
import { IniciarSesionComponent } from './iniciarse/iniciar-sesion/iniciar-sesion.component';
import { PiecieraComponent } from './pieciera/pieciera.component';
import { AspiranteRegistroDatosComponent } from './aspirante/aspirante-registro-datos/aspirante-registro-datos.component';
import { AspiranteRegistroHojaDeVidaComponent } from './Aspirante/aspirante-registro-hoja-de-vida/aspirante-registro-hoja-de-vida.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AspiranteRegistroComponent,
    EmpresaRegistroComponent,
    IniciarSesionComponent,
    PiecieraComponent,
    AspiranteRegistroDatosComponent,
    AspiranteRegistroHojaDeVidaComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
