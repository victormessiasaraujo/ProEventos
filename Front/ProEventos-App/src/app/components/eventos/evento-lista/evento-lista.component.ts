import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})

export class EventoListaComponent implements OnInit {

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ){ }

  modalRef: BsModalRef | undefined;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public larguraImagem = 100;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtrarListado = '';

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

  public ngOnInit(): void {
    this.spinner.show();
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
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Eventos.', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
    // this.eventoService.getEventos().subscribe(
    //   (_eventos: Evento[]) => {
    //     this.eventos = _eventos;
    //     this.eventosFiltrados = this.eventos;
    //   },
    //   error => console.log(error)
    // );
  }

  openModal(template: TemplateRef<any>) : void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento foi deletado com sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
