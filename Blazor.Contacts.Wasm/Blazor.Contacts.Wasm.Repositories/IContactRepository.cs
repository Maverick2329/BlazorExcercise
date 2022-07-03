using Blazor.Contacts.Wasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repositories
{
    public interface IContactRepository
    {
        Task<bool> InsetContact(Contact conctact);
        Task<bool> UpdateContact(Contact contact);
        Task DeleteContact(int id);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
    }
}
