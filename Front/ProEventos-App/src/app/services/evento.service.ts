import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable(
  //{providedIn: 'root'}
)

export class EventoService {

  baseURL = 'https://localhost:5001/api/Eventos';

  constructor(private http: HttpClient) { }

  getEventos(){
    return this.http.get(this.baseURL);
  }

}
