import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  //providers: [EventoService]
})
export class EventosComponent implements OnInit {


  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  private filtrarListado: string = '';

  public exibirImagem = true;
  public larguraImagem = 100;
  public margemImagem = 2;

  public get filtroLista():string{
    return this.filtrarListado;
  }

  public set filtroLista(value: string){
    this.filtrarListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
        evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                  evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )

  }

  constructor(private eventoService: EventoService) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public alterarEstadoImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos() : void {

    this.eventoService.getEventos().subscribe({
      next: (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => console.log(error),
      complete: () => {}
    });
    // this.eventoService.getEventos().subscribe(
    //   (_eventos: Evento[]) => {
    //     this.eventos = _eventos;
    //     this.eventosFiltrados = this.eventos;
    //   },
    //   error => console.log(error)
    // );
  }

}
