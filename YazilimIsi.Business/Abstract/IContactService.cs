using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAllContactMessages();
        Contact GetMessageById(int Id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
