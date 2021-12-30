import { Component, OnInit } from '@angular/core';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  //providers: [EventoService]
})
export class EventosComponent implements OnInit {


  public eventos: any = [];
  public eventosFiltrados: any = [];
  private _filtroLista: string = '';

  exibirImagem: boolean = true;
  larguraImagem: number = 100;
  margemImagem: number = 2;

  public get filtroLista():string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter((
        evento: {
          tema: string;
          local : string
        }
      ) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
           evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )

  }

  constructor(private eventoService: EventoService) { }

  ngOnInit(): void {
    this.getEventos();
  }

  alterarEstadoImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos() : void {
    this.eventoService.getEventos().subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }

}
