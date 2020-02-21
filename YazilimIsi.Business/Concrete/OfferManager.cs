using System;
using System.Collections.Generic;
using System.Linq;
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
            return _offerDal.Get(x => x.Id == Id, x => x.Developer, x => x.Job);
        }

        public List<Offer> GetOffersByDeveloperId(int developerId)
        {
            return _offerDal.GetAll(x => x.DeveloperId == developerId, x => x.Developer, x => x.Job).OrderByDescending(x => x.Id).ToList();
        }

        public List<Offer> GetOffersByJobId(int jobId)
        {
            return _offerDal.GetAll(x => x.JobId == jobId, x => x.Developer, x => x.Job).ToList();
        }

        public List<Offer> GetOffersByUserId(int userId)
        {
            return _offerDal.GetAll(x => x.Job.UserId == userId, x => x.Developer, x => x.Job).ToList();
        }

        public List<Offer> GettAllOffers()
        {
            return _offerDal.GetAll(null, x => x.Developer, x => x.Job).ToList();
        }

        public void Update(Offer offer)
        {
            _offerDal.Update(offer);
        }
    }
}
