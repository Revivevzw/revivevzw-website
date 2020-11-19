using Revivevzw.Business.Repositories;
using Revivevzw.DataAccess;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Revivevzw.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        public void Subscribe(SubscribeRequest request)
        {
            var email = request.Email;
            if (!IsEmailValid(email)) throw new ApplicationException("Invalid email.");
            var person = new Leden()
            {
                Email = email,
                Nieuwsbrief = "Y"
            };

            this.personRepository.Add(person);
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
