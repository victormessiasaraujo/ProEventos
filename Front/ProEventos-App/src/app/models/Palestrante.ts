import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
  palestranteId : number;
  nome : string;
  miniCurriculo : string;
  imagemURL : string;
  telefone : string;
  email : string;
  redesSociais : RedeSocial[];
  palestrantesEventos : Evento[];
}
