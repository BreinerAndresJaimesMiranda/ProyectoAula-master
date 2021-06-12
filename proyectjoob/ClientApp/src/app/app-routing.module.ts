import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AspiranteRegistroComponent } from './aspirante/aspirante-registro/aspirante-registro.component';
import { EmpresaRegistroComponent } from './empresa/empresa-registro/empresa-registro.component';
import { IniciarSesionComponent } from './iniciarse/iniciar-sesion/iniciar-sesion.component';
import { AspiranteRegistroDatosComponent } from './aspirante/aspirante-registro-datos/aspirante-registro-datos.component';
import { AspiranteRegistroHojaDeVidaComponent } from './Aspirante/aspirante-registro-hoja-de-vida/aspirante-registro-hoja-de-vida.component';

const routes: Routes = [
  {
    path: 'aspiranteRegistro',
    component:AspiranteRegistroComponent
  },
  {
    path: 'empresaRegistro',
    component:EmpresaRegistroComponent
  },
  {
    path:'iniciarSesion',
    component:IniciarSesionComponent
  },
  {
    path:'aspiranteRegistroDatos',
    component:AspiranteRegistroDatosComponent
  },
  {
    path:'AspiranteRegistroHojaDeVida',
    component:AspiranteRegistroHojaDeVidaComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
