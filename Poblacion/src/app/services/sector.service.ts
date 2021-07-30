import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SectorService {

  private myAppUrl = 'https://localhost:44349/';
  private MyApiUrl = 'api/Sector/';

  constructor(private http : HttpClient) { }

  getlistSectores(): Observable <any>{
    return this.http.get(this.myAppUrl+this.MyApiUrl);
  }

}
