using Revivevzw.DataAccess;
using System;
using System.Linq;

namespace Revivevzw.Business.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly REVIVEContext dbContext;

        public PersonRepository(REVIVEContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Leden person)
        {
            if (PersonExists(person.Email)) return;
            this.dbContext.Set<Leden>().Add(person);
            this.dbContext.SaveChanges();
        }

        private bool PersonExists(string email)
        {
            return this.dbContext.Set<Leden>().Any(x => x.Email.ToLower() == email.ToLower());
            //return this.dbContext.Set<Leden>().Any(x => email.Equals(x.Email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
