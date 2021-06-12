import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { Aspirante } from '../models/aspirante';
import { HojaDeVida } from '../models/hoja-de-vida';

@Component({
  selector: 'app-aspirante-registro-hoja-de-vida',
  templateUrl: './aspirante-registro-hoja-de-vida.component.html',
  styleUrls: ['./aspirante-registro-hoja-de-vida.component.css']
})
export class AspiranteRegistroHojaDeVidaComponent implements OnInit {
  hojadevida:HojaDeVida;
  aspirante:Aspirante;
  formGroup: FormGroup;
  constructor(private aspiranteService: AspiranteService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm(){
    this.hojadevida=new HojaDeVida();
    this.hojadevida.DescripcionPerfilLaboral='';
    this.hojadevida.Nombre='';
    this.formGroup = this.formBuilder.group({
    DescripcionPerfilLaboral:[this.hojadevida.DescripcionPerfilLaboral, Validators.required],
    Nombre:[this.hojadevida.Nombre, Validators.required],
    });
  }

  onSubmit() {
    this.addHojaDeVida();
  }
  addHojaDeVida(){
    this.aspirante=new Aspirante();
    this.aspiranteService.getLocal().subscribe(p=>this.aspirante=p);
    this.hojadevida=this.formGroup.value;
    this.hojadevida.AspiranteId=this.aspirante.Correo;
    this.aspiranteService.postHojaDeVida(this.hojadevida).subscribe(p=>{
      if(p!=null){
        console.log('Se agrego una nueva persona');
        this.hojadevida=p;
      }
    });
  }
  get control() { return this.formGroup.controls; }
}

