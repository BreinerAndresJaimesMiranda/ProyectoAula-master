import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { Aspirante } from '../models/aspirante';

@Component({
  selector: 'app-aspirante-registro',
  templateUrl: './aspirante-registro.component.html',
  styleUrls: ['./aspirante-registro.component.css']
})
export class AspiranteRegistroComponent implements OnInit {
  aspirante:Aspirante;
  formGroup: FormGroup;
  ConfirmarContra:string;
  constructor(private aspiranteService: AspiranteService,private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  } 

  private buildForm(){
    this.aspirante=new Aspirante();
    this.aspirante.TipoDocumento='';
    this.aspirante.Correo='';
    this.aspirante.Contrasenia='';
    this.ConfirmarContra='';
    this.aspirante.Identificacion='';
    this.aspirante.Nombres='';
    this.aspirante.Apellidos='';
    this.aspirante.Edad=0;
    this.aspirante.SalarioTrabajoPreferido='';
    this.aspirante.HorarioTrabajoPreferido='';
    this.aspirante.Telefono='';
    this.aspirante.Genero='';
    this.aspirante.Pais='';
    this.aspirante.Departamento='';
    this.aspirante.Ciudad='';
    this.aspirante.Nacionalidad='';
    this.formGroup = this.formBuilder.group({
      TipoDocumento:[this.aspirante.TipoDocumento, Validators.required],
      Correo:[this.aspirante.Correo,[Validators.required,Validators.email] ],
      Contrasenia:[this.aspirante.Contrasenia, Validators.required],
      Identificacion:[this.aspirante.Identificacion, [Validators.required,Validators.pattern('[0-9]*')]],
      Nombres:[this.aspirante.Nombres, Validators.required],
      Apellidos:[this.aspirante.Apellidos, Validators.required],
      Edad:[this.aspirante.Edad, [Validators.required,Validators.min(13)]],
      SalarioTrabajoPreferido:[this.aspirante.SalarioTrabajoPreferido, [Validators.required,Validators.pattern('[0-9]*')]],
      HorarioTrabajoPreferido:[this.aspirante.HorarioTrabajoPreferido, Validators.required],
      Telefono:[this.aspirante.Telefono, [Validators.required,Validators.pattern('[0-9]*')]],
      FechaNacimiento:[this.aspirante.FechaNacimiento, Validators.required],
      Genero:[this.aspirante.Genero, Validators.required],
      Pais:[this.aspirante.Pais, Validators.required],
      Departamento:[this.aspirante.Departamento, Validators.required],
      Ciudad:[this.aspirante.Ciudad, Validators.required],
      Nacionalidad:[this.aspirante.Nacionalidad, Validators.required],
    });
    
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
    
    

  }
  add(){
    this.aspirante=this.formGroup.value;
    this.aspiranteService.postLocal(this.aspirante);
    this.aspiranteService.post(this.aspirante).subscribe(p=>{
      if(p!=null){
        console.log('Se agrego una nuevo aspirante');
        this.aspirante=p;
      }
    });
  }

  get control() { return this.formGroup.controls; }
}
