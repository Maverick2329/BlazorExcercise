﻿using Blazor.Contacts.Wasm.Repositories;
using Blazor.Contacts.Wasm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Contact contact)
        {
            if (contact == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contact.FirstName))
                ModelState.AddModelError("FirstName", "First name can't be empty");
            
            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("LastName", "Last name can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactRepository.InsetContact(contact);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contact.FirstName))
                ModelState.AddModelError("FirstName", "First name can't be empty");

            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("LastName", "Last name can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactRepository.UpdateContact(contact);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _contactRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactRepository.GetDetails(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactRepository.DeleteContact(id);
        }
    }
}
