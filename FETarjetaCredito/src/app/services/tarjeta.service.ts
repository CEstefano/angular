import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TarjetaService {

  private myAppUrl = 'https://localhost:44339/';
  private MyApiUrl = 'api/tarjeta/';  //Aqui puedo concatenar despues del / los valores para el delete o alguna tarjeta

  constructor(private http : HttpClient) { }

  getListTarjetas(): Observable<any> {
    return this.http.get(this.myAppUrl + this.MyApiUrl);
  }

  deleteTarjeta(id : number): Observable<any>{
    return this.http.delete(this.myAppUrl + this.MyApiUrl + id);
  }

  saveTarjeta(tarjeta : any): Observable<any>{
    return this.http.post(this.myAppUrl + this.MyApiUrl , tarjeta);
  }
}
