using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.Entities;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Domain.AnimalManagement.AggregateRoot;

public class Volunteer : Shared.Entity<VolunteerId> , ISoftDeletable
{
    private readonly List<Animal> _animals = [];
    private bool _isDeleted = false;

    private Volunteer(VolunteerId id) : base(id)
    {
    }

    public Volunteer(
        VolunteerId id,
        FullName fullName,
        PhoneNumber phone,
        Email email,
        Description description,
        ExsperienceYears experience,
        SocialDetails socialNetworks,
        RequisiteDetails requisiteCollection) : base(id)
    {
        FullName = fullName;
        Phone = phone;
        Email = email;
        Description = description;
        Experience = experience;
        SocialNetworks = socialNetworks;
        RequisiteCollection = requisiteCollection;
    }


    public FullName FullName { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public Email Email { get; private set; }
    public Description Description { get; private set; }
    public ExsperienceYears Experience { get; private set; }
    public SocialDetails SocialNetworks { get; private set; }
    public RequisiteDetails RequisiteCollection { get; private set; }
    public IReadOnlyList<Animal> Animals => _animals;

    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        FullName fullName,
        PhoneNumber phoneNumber,
        Email email,
        Description description,
        ExsperienceYears experience,
        SocialDetails socialNetworks,
        RequisiteDetails requisiteCollection)

    {
        return new Volunteer(
            id,
            fullName,
            phoneNumber,
            email,
            description,
            experience,
            socialNetworks,
            requisiteCollection);
    }

    public UnitResult<Error> AddAnimals(IEnumerable<Animal> animals)
    {
        _animals.AddRange(animals);

        return Result.Success<Error>();
    }
    
    public int GetAnimalCountByStatus(HelpStatus status)
    {
        return _animals.Count(a => a.Status == status); 
    }

    public void UpdateMainInfo(
        PhoneNumber phone,
        Description description,
        Email email,
        ExsperienceYears experienceYears)
    {
        Phone = phone;
        Description = description;
        Email = email;
        Experience = experienceYears;
    }
    public void UpdateSocialNetworks(SocialDetails newSocialNetworks)
    {
        SocialNetworks = newSocialNetworks;
    }

    public void UpdateRequisiteCollection(RequisiteDetails newRequisiteCollection)
    {
        RequisiteCollection = newRequisiteCollection;
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