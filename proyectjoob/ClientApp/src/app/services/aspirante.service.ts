import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Aspirante } from '../aspirante/models/aspirante';
import { catchError, tap} from 'rxjs/operators';
import { HojaDeVida } from '../aspirante/models/hoja-de-vida';
import { DatoAcademico } from '../aspirante/models/dato-academico';
import { DatoLaboral } from '../aspirante/models/dato-laboral';


@Injectable({
  providedIn: 'root'
})
export class AspiranteService {
  baseUrl:string
  constructor(private http:HttpClient,
    @Inject ('BASE_URL') baseUrl : string) { 
      this.baseUrl=baseUrl;
    }

    
    get():Observable<Aspirante[]>{
      return this.http.get<Aspirante[]>(this.baseUrl+'api/Aspirante').pipe(
        tap(),
        catchError(error=>{
          console.log('se ha presentado un error al registrar los datos')
          return of(error as Aspirante[])
        })
      );
      
    }

    post(persona:Aspirante):Observable<Aspirante>{
      return this.http.post<Aspirante>(this.baseUrl+'api/Aspirante',persona).pipe(
        tap(_=>console.log("Los datos se guardaron Satisfactoriamente")),
        catchError(error=>{
          console.log('se ha presentado un error al registrar los datos')
          return of(persona)
        })
      )
    }

    postHojaDeVida(hojaDevida:HojaDeVida):Observable<HojaDeVida>{
      return this.http.post<HojaDeVida>(this.baseUrl+'api/HojaDeVida',hojaDevida).pipe(
        tap(_=>console.log("Los datos De la hoja de vida se guardaron Satisfactoriamente")),
        catchError(error=>{
          console.log('se ha presentado un error al registrar los datos')
          return of(error as HojaDeVida)
        })
      )
    }

    postLocal(persona:Aspirante):Observable<Aspirante>{
      localStorage.setItem('datos',JSON.stringify(persona));
      return of(persona);
    }
    getLocal(): Observable<Aspirante>{
      let persona: Aspirante;
      persona= new Aspirante();
      persona=JSON.parse(localStorage.getItem('datos'));
      return of(persona);
    }

    postDatoAcademico(DatoAcademico:DatoAcademico):Observable<DatoAcademico>{
      return this.http.post<DatoAcademico>(this.baseUrl+'api/DatoAcademico',DatoAcademico).pipe(
        tap(_=>console.log("El Dato Academico se guardo Satisfactoriamente")),
        catchError(error=>{
          console.log('se ha presentado un error al registrar los datos')
          return of(error as DatoAcademico)
        })
      )
    }

    postDatoLaboral(DatoLaboral:DatoLaboral):Observable<DatoLaboral>{
      return this.http.post<DatoLaboral>(this.baseUrl+'api/DatoLaboral',DatoLaboral).pipe(
        tap(_=>console.log("El Dato Laboral se guardo Satisfactoriamente")),
        catchError(error=>{
          console.log('se ha presentado un error al registrar los datos')
          return of(error as DatoLaboral)
        })
      )
    }
}
