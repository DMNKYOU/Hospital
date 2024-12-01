using System.Net.Http.Json;
using Bogus;
using PMI.Hospital.Contracts.People;
using PMI.Hospital.Core.Enums;
using PMI.Hospital.MockHospitalData;

const string host = "https://localhost:52703"; //should be updated before start
var httpClient = new HttpClient { BaseAddress = new Uri(host) };

var fakerPerson = new Faker<PersonCreateRequest>()
    .RuleFor(p => p.Id, f => Guid.NewGuid().ToString())
    .RuleFor(p => p.Use, f => f.PickRandom(new[] { "official", "unformal", "other" }))
    .RuleFor(p => p.Family, f => f.Name.LastName())
    .RuleFor(p => p.FirstName, f => f.Name.FirstName())
    .RuleFor(p => p.MiddleName, f => f.Name.Suffix())
    .RuleFor(p => p.Gender, f => f.PickRandom(new[] { Gender.Male, Gender.Female, Gender.Unknown, Gender.Other }))
    .RuleFor(p => p.BirthDate, f => f.Date.Past(20).AddMinutes(-60));

var people = fakerPerson.Generate(100);

foreach (var person in people)
{
    var responsePerson = await httpClient.PostAsJsonAsync($"{People.Create}", person);
    var responsePatient = await httpClient.PostAsJsonAsync($"{Patients.Create}", new Patient(person.Id, true));
    Console.WriteLine(responsePatient.IsSuccessStatusCode
        ? $"Created patient: {person.Id}"
        : "Error creating patient");
}

public record Patient(string PersonId, bool Active);
