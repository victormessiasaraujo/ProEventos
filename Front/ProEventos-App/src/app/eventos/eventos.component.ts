import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {


  public eventos: any = [
    {
      Tema: "Angular 12",
      Local: "São Paulo"
    },
    {
      Tema: "Net Core",
      Local: "Rio de Janeiro"
    },
    {
      Tema: "Web API",
      Local: "Belo Horizonte"
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
