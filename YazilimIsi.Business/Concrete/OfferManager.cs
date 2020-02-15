using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class OfferManager : IOfferService
    {

        private IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public void Add(Offer offer)
        {
            _offerDal.Add(offer);
        }

        public void Delete(Offer offer)
        {
            _offerDal.Delete(offer);
        }

        public Offer GetOfferById(int Id)
        {
            return _offerDal.Get(x => x.Id == Id);
        }

        public List<Offer> GettAllOffers()
        {
            return _offerDal.GetAll();
        }

        public void Update(Offer offer)
        {
            _offerDal.Update(offer);
        }
    }
}
