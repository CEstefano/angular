import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  private myAppUrl = 'https://localhost:44349/';
  private MyApiUrl = 'api/Persona/';

  constructor(private http : HttpClient) {}

      getlistPersonas(): Observable <any> {
        return this.http.get(this.myAppUrl + this.MyApiUrl);
      }

      deletePersona(id : number): Observable<any>{
        return this.http.delete(this.myAppUrl + this.MyApiUrl + id);
      }

      savePersona(tarjeta : any): Observable<any> {
        return this.http.post(this.myAppUrl + this.MyApiUrl , tarjeta);
      }

}
