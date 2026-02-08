## Gebruikte technologieën
- .NET 10
- Entity Framework Core
- Entity Framework Core Sqlite
- XUnit
- Moq
- FluentAssertions

## Structuur van de code
- EPD is opgebouwd volgens de Clean Architecture, waarbij de code is georganiseerd in verschillende lagen: 
  - Domain: bevat o.a. de entiteiten.
  - Application: bevat services die de business logica implementeren, DTOs en de interfaces voor de repositories die in de infrastructuurlaag worden geïmplementeerd.
  - Infrastructure: bevat de implementaties van de interfaces (Repositories) en database context.
  - Representation: bevat de nodige componenten die verantwoordelijk zijn voor de presentatie van de data aan de gebruikers (startpunt is het Program.cs bestand).

## Gebruikte Design Patterns
- Repository Pattern (details verbergen van toegang tot de data).
- Dependency Injection (constructor injection).
- Factory Pattern.
- Clean Architecture (Architectural pattern).

## SOLID Principles
- Single Responsibility Principle: elke klasse heeft zijn eigen verantwoordelijkheid, bvb. de klasse Patient.
- Open/Closed Principle: open voor uitbreidingen, gesloten voor wijzigingen, bvb. via Dependency Injection - interfaces.
- Liskov Substitution Principle: objecten zijn vervangbaar door instanties van hun subtypes, bvb. de IIDExists - GetExistingId<T>.
- Interface Segregation Principle: meerdere interfaces gebruiken i.p.v. 1 interface, bvb. IPatientRepository en IDoctorRepository.
- Dependency Inversion Principle: een object moet zijn afhankelijkheden niet zelf aanmaken, maar krijgen deze van buitenaf geïnjecteerd. Bvb. de PatientService heeft een IPatientRepository injectie in plaats van de repository zelf te moeten aanspreken.

## DDD
- Entities: er zijn 3 entiteiten (Patiënt, Dokter en Afspraak), ze hebben elk o.a. een identiteit via de Id property.
- Value Objects: objecten die een betekenisvolle waarde hebben, bvb. e-mailadres.
- Aggregates: bvb. Patient is een aggregate root, een afspraak kan alleen toegevoegd worden via de patiënt.
- Repositories: voor het opslaan/wijzigen van entiteiten en Value Objects.

## Testen
- Unit Tests: deze zijn geïmplementeerd voor o.a. de services te testen.
- Mocking: Er wordt gebruik gemaakt van Moq.

## Extra functionaliteiten voor in de toekomst
- Extra testen: Er kunnen meer unit testen geïmplementeerd worden zodat alle functionaliteiten van de applicatie goed worden getest.
- Error handling: extra error handlings kunnen geïmplementeerd worden zodat de applicatie robuuster is.
- Bvb. voor het verwijderen van een patiënt:
	- Controleren of er nog openstaande afspraken zijn voordat we de patiënt verwijderen, en een foutmelding geven als dat het geval is.
	- Vragen om bevestiging voordat we de patiënt daadwerkelijk verwijderen, om te voorkomen dat patiënten per ongeluk worden verwijderd.
- Afspraak toevoegen/dokter verwijderen/patiënt verwijderen: bvb. op basis van familienaam opzoeken, indien er meerdere resultaten gevonden zijn dan filteren op voornaam etc.
- CQRS - Mediatr implementatie (momenteel niet nodig aangezien het een paar simpele acties betreft, het is wel handig wanneer de applicatie complexer wordt).
- Overal comments plaatsen.
- Extra Value Objects.
