using Task_Auth.Models;

namespace Task_Auth.Repositories
{
    public class ProdottoRepo : IRepo<Prodotto>
    {

        private readonly TaskAuthContext _context;
        public ProdottoRepo(TaskAuthContext context)
        {
            _context = context;
        }
        public bool Create(Prodotto entity)
        {
            try
            {
                _context.Prodottos.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.ToString());
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                Prodotto? temp = Get(id);
                if (temp != null)
                {
                    _context.Prodottos.Remove(temp);
                    _context.SaveChanges();
                    return true;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public Prodotto? Get(int id)
        {
            return _context.Prodottos.Find(id);
        }

        public IEnumerable<Prodotto> GetAll()
        {
            return _context.Prodottos.ToList();
        }

        public bool Update(Prodotto entity)
        {
            try
            {
                _context.Prodottos.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        public Prodotto? GetByCodice(string codice)
        {
            try
            {
                return _context.Prodottos.FirstOrDefault(p => p.Codice == codice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
                return null;
        }
    }
}
