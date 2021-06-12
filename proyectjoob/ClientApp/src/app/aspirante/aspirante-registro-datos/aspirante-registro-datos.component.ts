import { StringMap } from '@angular/compiler/src/compiler_facade_interface';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { Aspirante } from '../models/aspirante';
import { DatoAcademico } from '../models/dato-academico';
import { DatoLaboral } from '../models/dato-laboral';

@Component({
  selector: 'app-aspirante-registro-datos',
  templateUrl: './aspirante-registro-datos.component.html',
  styleUrls: ['./aspirante-registro-datos.component.css']
})
export class AspiranteRegistroDatosComponent implements OnInit {
  datoAcademico:DatoAcademico;
  datoLaboral:DatoLaboral;
  formGroupdatoAcademico: FormGroup;
  formGroupdatoLaboral: FormGroup;
  aspirante:Aspirante;
  area:String;
  datosAcademicos:DatoAcademico[]=[];
  datosLaborales:DatoLaboral[]=[];
  validacion:boolean=true;
  
  constructor(private aspiranteService: AspiranteService,private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
    this.formGroupdatoAcademico.controls.NivelEducativo.valueChanges.subscribe(p=>{
      if(p !=='Nivel de estudios' && p !=='Educacion Básica Primaria' && p !=='Bachillerato - Educación Media'){
        var inputAreaAcademica=<HTMLFormElement>document.getElementById("prueba");
        inputAreaAcademica.disabled=false;
        this.formGroupdatoAcademico.controls.AreaEstudio.setValidators(Validators.required);
        this.formGroupdatoAcademico.controls.AreaEstudio.updateValueAndValidity();
      }else{
        var inputAreaAcademica=<HTMLFormElement>document.getElementById("prueba");
        inputAreaAcademica.disabled=true;
        this.formGroupdatoAcademico.controls.AreaEstudio.setValidators(null);
        this.formGroupdatoAcademico.controls.AreaEstudio.updateValueAndValidity();
      }
    })
  }



  private buildForm(){
    this.datoAcademico=new DatoAcademico();
    this.datoLaboral=new DatoLaboral();
    this.datoAcademico.AreaEstudio='';
    this.datoAcademico.NombreCentroAcademico='';
    this.datoAcademico.NivelEducativo='Nivel de estudios';
    this.datoAcademico.EstadoCurso='Seleccione el Estado';
    this.datoLaboral.NombreEmpresa='';
    this.datoLaboral.Cargo='';
    this.datoLaboral.Area='';
    this.formGroupdatoAcademico = this.formBuilder.group({
      NombreCentroAcademico:[this.datoAcademico.NombreCentroAcademico, Validators.required],
      NivelEducativo:[this.datoAcademico.NivelEducativo, [Validators.required,this.validaNivelEducativo]],
      AreaEstudio:[this.datoAcademico.AreaEstudio],
      EstadoCurso:[this.datoAcademico.EstadoCurso, [Validators.required,this.validaEstadoCurso]],
      FechaInicio:[this.datoAcademico.FechaInicio, Validators.required],
      FechaFinalizacion:[this.datoAcademico.FechaFinalizacion, Validators.required],
    });
    this.formGroupdatoLaboral = this.formBuilder.group({
      NombreEmpresa:[this.datoLaboral.NombreEmpresa, Validators.required],
      Cargo:[this.datoLaboral.Cargo, Validators.required],
      Area:[this.datoLaboral.Area, Validators.required],
      FechaInicio:[this.datoLaboral.FechaInicio, Validators.required],
      FechaFinalizacion:[this.datoLaboral.FechaFinalizacion, Validators.required],
    });
  }

  validacionUniversitaria(){
    if(this.formGroupdatoAcademico.controls.NivelEducativo.value !=='Nivel de estudios' && this.formGroupdatoAcademico.controls.NivelEducativo.value !=='Educacion Básica Primaria' && this.formGroupdatoAcademico.controls.NivelEducativo.value !=='Bachillerato - Educación Media'){
      return true;
    }else{
      return false;
    }
  }

  onSubmitDatoAcademico(){this.addDatoAcademico();this.reset();}
  onSubmitDatoLaboral(){this.addDatoLaboral();this.resetLaborales();}
  addDatoAcademico(){
    this.aspirante=new Aspirante();
    this.aspiranteService.getLocal().subscribe(p=>this.aspirante=p);
    this.datoAcademico=this.formGroupdatoAcademico.value;
    this.datoAcademico.FechaInicio=new Date(this.formGroupdatoAcademico.controls.FechaInicio.value.toString());
    this.datoAcademico.FechaFinalizacion=new Date(this.formGroupdatoAcademico.controls.FechaFinalizacion.value.toString());
    this.datoAcademico.AspiranteId=this.aspirante.Correo; 
    this.datosAcademicos.push(this.datoAcademico);
    this.aspiranteService.postDatoAcademico(this.datoAcademico).subscribe(p=>{
      if(p!=null){
        console.log('Se agrego un nuevo dato academico');
        this.datoAcademico=p;
      }
    });
  }

  addDatoLaboral(){
    this.aspirante=new Aspirante();
    this.aspiranteService.getLocal().subscribe(p=>this.aspirante=p);
    this.datoLaboral=this.formGroupdatoLaboral.value;
    this.datoLaboral.FechaInicio=new Date(this.formGroupdatoLaboral.controls.FechaInicio.value.toString());
    this.datoLaboral.FechaFinalizacion=new Date(this.formGroupdatoLaboral.controls.FechaFinalizacion.value.toString());
    this.datoLaboral.AspiranteId=this.aspirante.Correo;
    this.datosLaborales.push(this.datoLaboral);
    this.aspiranteService.postDatoLaboral(this.datoLaboral).subscribe(p=>{
      if(p!=null){
        console.log('Se agrego un nuevo dato laboral');
        this.datoLaboral=p;
      }
    });
  }
  reset(){
    var resetForm = <HTMLFormElement>document.getElementById("xd");
    resetForm.reset();
    var inputAreaAcademica=<HTMLFormElement>document.getElementById("prueba");
    inputAreaAcademica.disabled=true;
  }
 resetLaborales(){
  var resetForm = <HTMLFormElement>document.getElementById("DatosLaborales");
  resetForm.reset();
 }
 private validaNivelEducativo(control: AbstractControl){
  const nivelEducativo=control.value;
  if(nivelEducativo === "Nivel de estudios"){
    return { ValidnivelEducativo:true, messageNivelAcademico: 'Porfavor Seleccione una opcion valida'};
  }
  return null;
 }
 private validaEstadoCurso(control: AbstractControl){
  const EstadoCurso=control.value;
  if(EstadoCurso === "Seleccione el Estado"){
    return { ValidEstadoCurso:true, messageEstadoCurso: 'Porfavor Seleccione una opcion valida'};
  }
  return null;
 }
  get controldatoAcademico() { return this.formGroupdatoAcademico.controls; }
  get controldatoLaboral() { return this.formGroupdatoLaboral.controls; }

}
