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

## Naloga

S pomočjo programskega jezika C# in ogrodja ASP.Net načrtujte in implementirajte spletno aplikacijo, pri tem pa uporabite MVC načrtovalski vzorec.

Spletna aplikacija naj omogoča uporabniku najavo in rezervacijo termina ter točke dostave za določeno pošiljko v enega izmed treh skladišč podjetja Lorem-Ipsum. Vsako skladišče ima 5 azpoložljivih dostavnih točk. V aplikaciji naj bodo 3 različne uoprabniške vloge, in sicer:

a) administrator: zaposlen v podjetju, kateremu se dostavlja pošiljka (ima vpogled in možnost dodajanja, brisanja in urejanja vseh že vnešenih dostav).

b) uporabnik: zaposlen v podjetju, ki bo dostavilo pošiljko (ima možnost vnosa najave dostave in spreminjanja podatkov le za svoje pošiljke).

c) skladiščnik: oseba, ki je zaposlena le na 1 izmed skladišč v podjetju, ki se mu dostavlja pošiljka (ima možnost potrjevanj oziroma zaključevanja dostav, ko je ta dostavljena oziroma prevzeta).

Običajni pozitivni diagram poteka procesa si sledi tako, da se uporabnik prijavi v spletno aplikacijo, nato vnese številko dostave, na osnovi tega se mu za določeno skladišče v tedenskem koledarju prikažejo razpoložljiva mesta in termini. Ko uporabnik izbere termin in dostavno točko, se mu po potrditvi izdela povzetek oziroma poročilo, ki ga je moč tudi natisniti ali poslati kot priponko v elektronskem sporočilu.

Pošiljke, s številko dostav v navedenih območjih, se lahko dostavijo v naslednja skladišča:

- 1000 do 1999 Skladišče 1 (razpoložljive točke 1,2,3,4,5)
- 2000 do 2999 Skladišče 2 (razpoložljive točke 1,2,3,4,5)
- 3000 do 3999 Skladišče 3 (razpoložljive točke 1,2,3,4,5)

Administrator ima možnost vpogleda, spreminjanja in vnašanja podatkov za vsa tri skladišča in vse pošiljke, lahko pa za XY podjetje in pošiljko doda oziroma vnese dostavo.
Skladiščnik po prevzemu pošiljke v sistemu zaključi oziroma potrdi dostavo za pošiljko, s to akcijo se proces tudi zaključi.

V kolikor boste, poleg opisanega procesa, opisali in načrtovali oziroma implementirali tudi druge funkcionalnosti, vam bo to doprineslo dodatne točke. Dodatne funkcionalnosti, kot so: možnost registracije, pozabljeno geslo, sistem obveščanja-sprememba termina s strani administratorja do uporabnika in obratno.
