using Task_Auth.Models;
using Task_Auth.Repositories;

namespace Task_Auth.Services
{
    public class ProdottoService
    {
        private readonly ProdottoRepo _repository;
        public ProdottoService(ProdottoRepo repository)
        {
            _repository = repository;
        }

        public bool InserisciProdotto(Prodotto pro)
        {
            Prodotto prodotto = new Prodotto()
            {
                Categoria = pro.Categoria,
                Descrizione = pro.Descrizione,
                Nome = pro.Nome,

            };
            return _repository.Create(prodotto);
        }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = _repository.GetAll().Select(p=>new Prodotto()
            {
                Nome = p.Nome,
                Categoria = p.Categoria,
                Codice = p.Codice,
                Descrizione=p.Descrizione,
                ProdottoId= p.ProdottoId
            }).ToList();  
            
            return elenco;
        }

        public bool EliminaProdotto(Prodotto pro)
        {
            if(pro.Codice is not null)
            {
                Prodotto? temp = _repository.GetByCodice(pro.Codice);
                if (temp is not null) 
                    return _repository.Delete(temp.ProdottoId);
            }
            return false;
        }

        public bool ModificaProdotto(Prodotto pro)
        
            {

                if (pro.Codice is not null)
                {
                    Prodotto? temp = _repository.GetByCodice(pro.Codice);

                    if (temp is not null)
                    {

                       
                    temp.Nome = pro.Nome;
                    temp.Descrizione = pro.Descrizione;
                    temp.Categoria=pro.Categoria;  
                        return _repository.Update(temp);
                    }
                }
                return false;
            
        }
    }
}
