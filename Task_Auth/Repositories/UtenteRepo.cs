using Task_Auth.Models;

namespace Task_Auth.Repositories
{
    public class UtenteRepo : IRepo<Utente>
    {

        private readonly TaskAuthContext _context;
        public UtenteRepo(TaskAuthContext context)
        {
            _context = context;
        }
        public bool Create(Utente entity)
        {
            try
            {
                _context.Utentes.Add(entity);
                _context.SaveChanges();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                Utente? temp = Get(id);
                if (temp != null) {
                    _context.Utentes.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public Utente? Get(int id)
        {
            return _context.Utentes.Find(id);
        }

        public Utente? GetByUsername(string username)
        {
            return _context.Utentes.FirstOrDefault(u =>u.Username == username);
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utentes.ToList();
        }

      
        public bool Update(Utente entity)
        {
            try
            {
                _context.Utentes.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;   
            }
        }
    }
}
