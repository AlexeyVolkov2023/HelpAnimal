using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.Entities;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Domain.AnimalManagement.AggregateRoot;

public class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly int _adoptedAnimalsCount;
    private readonly int _currentAnimalsCount;
    private readonly int _animalsInTreatmentCount;
    private readonly List<Animal> _animals = [];

    private Volunteer(VolunteerId id) : base(id)
    {
    }

    public Volunteer(
        VolunteerId id,
        FullName fullName,
        PhoneNumber phone,
        Email email,
        Description description,
        ExsperienceYears experience) : base(id)
    {
        FullName = fullName;
        Phone = phone;
        Email = email;
        Description = description;
        Experience = experience;
    }


    public FullName FullName { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public Email Email { get; private set; }
    public Description Description { get; private set; }
    public ExsperienceYears Experience { get; private set; }
    public SocialDetails? SocialNetworks { get; private set; }
    public RequisiteDetails? RequisiteCollection { get; private set; }
    public IReadOnlyList<Animal>? Animals { get; private set; }

    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        FullName fullName,
        PhoneNumber phoneNumber,
        Email email,
        Description description,
        ExsperienceYears experience)

    {
        return new Volunteer(
            id,
            fullName,
            phoneNumber,
            email,
            description,
            experience);
    }

    public UnitResult<Error> AddAnimals(IEnumerable<Animal> animals)
    {
        _animals.AddRange(animals);

        return Result.Success<Error>();
    }

    public int GetAdoptedAnimalsCount() => _adoptedAnimalsCount;

    public int GetCurrentAnimalsCount() => _currentAnimalsCount;

    public int GetAnimalsInTreatmentCount() => _animalsInTreatmentCount;
}