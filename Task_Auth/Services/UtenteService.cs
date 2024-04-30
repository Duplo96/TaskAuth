using Microsoft.EntityFrameworkCore;
using Task_Auth.Models;
using Task_Auth.Repositories;

namespace Task_Auth.Services
{
    public class UtenteService
    {

        private readonly UtenteRepo _repository;
        public UtenteService(UtenteRepo repository)
        {
            _repository = repository;
        }

        public bool InserisciUtente(Utente ute)
        {
            Utente utente = new Utente()
            {
               Username = ute.Username,
               Pass=ute.Pass,
               Tipo=ute.Tipo

            };
            return _repository.Create(utente);
        }

        public List<Utente> GetAll()
        {
            List<Utente> elenco = _repository.GetAll().Select(u => new Utente()
            {
                UtenteId = u.UtenteId,
                Username=u.Username,
                Pass=u.Pass,
                Tipo=u.Tipo
            }).ToList();

            return elenco;
        }

        public bool EliminaUtente(Utente ute)
        {
            if (ute.Username is not null)
            {
                Utente? temp = _repository.GetByUsername(ute.Username);
                if (temp is not null)
                    return _repository.Delete(temp.UtenteId);
            }
            return false;
        }

        public bool ModificaUtente(Utente ute)

        {

            if (ute.Username is not null)
            {
                Utente? temp = _repository.GetByUsername(ute.Username);

                if (temp is not null)
                {
                    temp.Tipo = ute.Tipo;
                    temp.Pass = ute.Pass;
                    temp.Username = ute.Username;
                    return _repository.Update(temp);
                }
            }
            return false;

        }

        public Utente? GetByUsername(string username)
        {
    
                Utente? temp = _repository.GetByUsername(username);
            return temp;
            
        }
    }
}
