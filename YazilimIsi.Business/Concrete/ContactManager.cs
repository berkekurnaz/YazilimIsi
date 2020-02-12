using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class ContactManager : IContactService
    {

        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        /* Yeni Bir Mesaj Ekleme */
        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        /* Bir Mesaj Silme */
        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        /* Butun Mesajlari Getirme */
        public List<Contact> GetAllContactMessages()
        {
            return _contactDal.GetAll();
        }

        /* Bir Mesaj Getirme */
        public Contact GetMessageById(int Id)
        {
            return _contactDal.Get(x => x.Id == Id);
        }

        /* Bir Mesaj Guncelleme */
        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
