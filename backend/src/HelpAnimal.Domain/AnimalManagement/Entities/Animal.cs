using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.AggregateRoot;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Domain.AnimalManagement.Entities;

public class Animal : Shared.Entity<AnimalId> , ISoftDeletable
{
    private bool _isDeleted = false;
    
    private Animal(AnimalId id) : base(id)
    {
    }


    private Animal(
        AnimalId id,
        AnimalData profile,
        IdentifierAnimal identifier,
        AnimalInformation information,
        Address address,
        PhoneNumber phone,
        AnimalsBirthday birthday,
        VaccinationDetails alreadyVaccinated,
        HelpStatus status,
        RequisiteDetails requisites,
        AnimalPhotosDetails animalPhotos) : base(id)
    {
        Profile = profile;
        Identifier = identifier;
        Information = information;
        AnimalAddress = address;
        Phone = phone;
        Birthday = birthday;
        AlreadyVaccinated = alreadyVaccinated;
        Status = status;
        CreatedAt = DateTime.Now;
        RequisiteCollection = requisites;
        AnimalPhotos = animalPhotos;
    }

    public AnimalData Profile { get; private set; }
    public IdentifierAnimal? Identifier { get; private set; }
    public AnimalInformation Information { get; private set; }
    public Address? AnimalAddress { get; private set; } = default!;
    public PhoneNumber? Phone { get; private set; } // Номер телефона для связи с владельцем
    public AnimalsBirthday Birthday { get; private set; }
    public VaccinationDetails? AlreadyVaccinated { get; private set; }
    public HelpStatus? Status { get; private set; } // Статус помощи
    public DateTime CreatedAt { get; set; }
    public AnimalPhotosDetails? AnimalPhotos { get; private set; }
    public RequisiteDetails? RequisiteCollection { get; private set; }


    public static Result<Animal, Error> Create(
        AnimalId id,
        AnimalData profile,
        IdentifierAnimal identifier,
        AnimalInformation information,
        Address address,
        PhoneNumber phone,
        AnimalsBirthday birthday,
        VaccinationDetails alreadyVaccinated,
        HelpStatus status,
        RequisiteDetails requisites,
        AnimalPhotosDetails animalPhotos)
    {
        return new Animal(
            id,
            profile,
            identifier,
            information,
            address,
            phone,
            birthday,
            alreadyVaccinated,
            status,
            requisites,
            animalPhotos);
    }
    
    public void Delete()
    {
        if (_isDeleted == false)
            _isDeleted = true;
    }

    public void Restore()
    {
        if (_isDeleted)
            _isDeleted = false;
    }
}