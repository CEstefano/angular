import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ZonaService {

  private myAppUrl = 'https://localhost:44349/';
  private MyApiUrl = 'api/Zona/';

  constructor(private http : HttpClient) { }

    getlistZonas(): Observable <any>{
      return this.http.get(this.myAppUrl+this.MyApiUrl);
    }

  }

