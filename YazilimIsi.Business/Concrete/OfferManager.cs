using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public List<Offer> GetOffersByJobId(int jobId)
        {
            List<Expression<Func<Offer, object>>> includesList = new List<Expression<Func<Offer, object>>>();
            includesList.Add(x => x.Developer);
            includesList.Add(x => x.Job);
            return _offerDal.GetAll(x => x.JobId == jobId, includesList);
        }

        public List<Offer> GettAllOffers()
        {
            List<Expression<Func<Offer, object>>> includesList = new List<Expression<Func<Offer, object>>>();
            includesList.Add(x => x.Developer);
            includesList.Add(x => x.Job);
            return _offerDal.GetAll(null, includesList);
        }

        public void Update(Offer offer)
        {
            _offerDal.Update(offer);
        }
    }
}
