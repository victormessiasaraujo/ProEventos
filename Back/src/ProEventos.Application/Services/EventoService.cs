using System;
using System.Threading.Tasks;
using ProEventos.Application.Contracts;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IGeralQuery _geralPersistence;
        private readonly IEventoQuery _eventPersistence;
        public EventoService(IGeralQuery geralPersistence, IEventoQuery eventPersistence)
        {
            this._geralPersistence = geralPersistence;
            this._eventPersistence = eventPersistence;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventPersistence.GetEventoByIdAsync(model.EventoId, false);
                }

                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int id, Evento model)
        {
            try
            {
                 var evento = await _eventPersistence.GetEventoByIdAsync(id, false);

                 if (evento == null) return null;

                 model.EventoId = evento.EventoId;
                 
                 _geralPersistence.Upadte(model);

                 if(await _geralPersistence.SaveChangesAsync())
                 {
                    return await _eventPersistence.GetEventoByIdAsync(model.EventoId,false);
                 }

                 return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int id)
        {
            try
            {
                 var evento = await _eventPersistence.GetEventoByIdAsync(id, false);

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

        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventPersistence.GetEventoByIdAsync(id, includePalestrantes);

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