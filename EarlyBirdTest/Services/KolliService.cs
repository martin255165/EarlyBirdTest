using FluentValidation.Results;
using EarlyBirdTest.DAL.Models;
using EarlyBirdTest.DAL.Repositories;
using EarlyBirdTest.Exceptions;
using EarlyBirdTest.Validations;

namespace EarlyBirdTest.Services
{
    public class KolliService
    {
        private readonly IKolliRepository _kolliRepository;

        public KolliService(IKolliRepository kolliRepository)
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

        public void InsertKolli(Kolli kolli)
        {
            KolliIdValidator kolliIdValidator = new KolliIdValidator();
            ValidationResult kolliIdValidationresults = kolliIdValidator.Validate(kolli.KolliId);

            KolliValidator kolliValidator = new KolliValidator();
            ValidationResult kolliValidationresults = kolliValidator.Validate(kolli);

            if (!kolliIdValidationresults.IsValid || !kolliValidationresults.IsValid)
                throw new KolliInvalidException(
                    kolliIdValidationresults.GetValidationErrors(), 
                    kolliValidationresults.GetValidationErrors());

            if (_kolliRepository.KolliExists(kolli.KolliId))
                throw new KolliAlreadyExistsException(kolli.KolliId);

            _kolliRepository.InsertKolli(kolli);
        }
    }
}
