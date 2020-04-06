# Hekatlon izziv Krka

Kazalo vsebine
=================
- [Predpogoji](#predpogoji)
- [Inštalacija in poganjanje](#inštalacija-in-poganjanje)
- [Uporabljene tehnologije](#uporabljene-tehnologije)
- [Uporabljen pristop](#uporabljen-pristop)
- [Struktura aplikacije](#struktura-aplikacije)


## Predpogoji

Pravilno poganjanje aplikacije preizkušeno s sledečimi razvijalskimi orodji:
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
- [SSMS 17.x](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)


## Inštalacija in poganjanje

Ko imate pripravljena razvijalska okolja, zaženite sledeče ukaze:

1. Odprite projekt v Visual Studiu
    - `Open project or solution -> poiščite preneseno mapo ter v podmapi WebApp/ odprite .sln datoteko`
    - Po potrebi izvedite `Restore NuGet Packages`

2. Nastavite povezavo do podatkovne baze v Visual Studiu
    - `WebApp -> appsettings.json -> "ConnectionStrings" -> "DefaultConnection"`
    
3. Zaženite migracije podatkovne baze
    - `dotnet ef database update` -> če uporabljate .NET Core CLI
    - `Update-Database -Project WebApp.Infrastructure` -> če uporabljate Packege Manager Console
    
4. Nato lahko zaženete aplikacijo


## Uporabljene tehnologije

- ASP.NET Core MVC 3.1
- Za pošiljanje e-mailov SendGrid

## Uporabljen pristop

- "Code first"
- "Soft delete"

## Struktura aplikacije

- WebApp.Domain -> organizacija podatkovnih modelov aplikacije
- WebApp.Infrastructure -> organizacija migracij in komunikaje z podatkovno bazo
- WebApp -> implementacija spletnega dela
