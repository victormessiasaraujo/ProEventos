using System;
using System.Threading.Tasks;
using ProEventos.Application.Contracts;
using ProEventos.Domain;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersistence;
        private readonly IEventoPersist _eventPersistence;
        public EventoService(IGeralPersist geralPersistence, IEventoPersist eventPersistence)
        {
            this._geralPersistence = geralPersistence;
            this._eventPersistence = eventPersistence;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventPersistence.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEventos(int eventoid, Evento model)
        {
            try
            {
                 var evento = await _eventPersistence.GetEventoByIdAsync(eventoid, false);

                 if (evento == null) return null;

                 model.Id = evento.Id;
                 
                 _geralPersistence.Upadte(model);

                 if(await _geralPersistence.SaveChangesAsync())
                 {
                    return await _eventPersistence.GetEventoByIdAsync(model.Id,false);
                 }

                 return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoid)
        {
            try
            {
                 var evento = await _eventPersistence.GetEventoByIdAsync(eventoid, false);

                 if (evento == null) throw new Exception("Evento não encontrado");
                 
                 _geralPersistence.Delete<Evento>(evento);

                 return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventPersistence.GetAllEventosAsync(includePalestrantes);

                 if(eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);

                 if(eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);

                 if(eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}