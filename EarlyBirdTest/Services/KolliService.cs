using EarlyBirdTest.DAL.Models;
using EarlyBirdTest.DAL.Repositories;
using EarlyBirdTest.Exceptions;
using EarlyBirdTest.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EarlyBirdTest.Services
{
    public class KolliService
    {
        private readonly KolliRepository _kolliRepository;

        public KolliService(KolliRepository kolliRepository)
        {
            _kolliRepository = kolliRepository ?? throw new ArgumentNullException(nameof(kolliRepository));
        }

        public List<Kolli> GetAllKollis()
        {
            return _kolliRepository.GetAllKollis();
        }

        public Kolli GetKolliById(string kolliId)
        {
            KolliIdValidator kolliIdValidator = new KolliIdValidator();
            ValidationResult results = kolliIdValidator.Validate(kolliId);
            if (!results.IsValid)
                throw new MalformedKolliIdException(results.GetValidationErrors());

            var kolli = _kolliRepository.GetKolliById(kolliId);
            if (kolli == null)
                throw new KolliNotFoundException(kolliId);

            return kolli;
        }


    }
}
