using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IOfferService
    {
        List<Offer> GettAllOffers();
        List<Offer> GetOffersByJobId(int jobId);

        Offer GetOfferById(int Id);
        void Add(Offer offer);
        void Update(Offer offer);
        void Delete(Offer offer);
    }
}
