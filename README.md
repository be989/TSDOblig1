# TSD2491_Oblig1
## Studentnummer:
253799

## Prosjektbeskrivelse:
Denne webapplikasjonen er laget i ASP.NET Core MVC som en del av Oblig 1 i TSD2491.

Formålet med denne obligen er:
- Git workflow med branches og commits
- Oppsett av en webapplikasjon i Visual Studio Code
- Bruk av MVC-strukturen (Model, View, Controller)
- Datamodellering med Entity Framework Core (Bruker-modell + CRUD)
- Dynamisk funksjonalitet med JavaScript

---

## Funksjonalitet som er implementert:

###  CRUD-funksjonalitet:
- Modell: `Bruker` med feltene `Navn`, `KontaktInfo`, `AntallSpill`
- Scaffolding brukt til å generere views og controller
- Brukeren kan opprettes, vises, redigeres og slettes
- URL: `/Brukers/`

###  Spill: 2-like memory game
- Egen visning: `Spill.cshtml` (`/Home/Spill`)
- Fargede ruter – klikk på to like for å fjerne dem
- Når alle par er funnet, vises meldingen **"Spillet er ferdig!"**

###  Brukerintegrasjon:
- Spiller skriver inn sitt navn før spillet
- Når spillet fullføres, blir `AntallSpill` økt i databasen for den brukeren

###  Rangering:
- Topp 10 brukere med flest fullførte spill vises under spillet
- Rangeringen oppdateres automatisk etter hvert spill (uten å refreshe siden)

---

## virkemidler som ble brukt:
- ASP.NET Core MVC
- Entity Framework Core med SQLite
- Git CLI og branches
- Visual Studio Code
- HTML, CSS, JavaScript

---

## Hvordan teste:
1. Start prosjektet med:
    ```bash
    dotnet run
    ```

2. Åpne nettleser og gå til:
    - `/Brukers/` for å opprette/redigere brukere
    - `/Home/Spill` for å spille spillet og se rangering

---

## Versjonskontroll:
- `master` inneholder alle commits
- Totalt: 7 commits 
- Branches: `student253799`, `student253799newFeatures` (merget)

---


>>>>>>> 740314e (La til README-fil for prosjektet)
