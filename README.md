# TSD2491 – Obligatorisk Oppgave 1 (2025)

🧑‍💻 Studentnummer: **253799**

Dette er en løsning på den obligatoriske oppgaven i faget TSD2491 ved USN.  
Prosjektet er bygget med ASP.NET Core MVC og inkluderer en brukermodell med CRUD-funksjonalitet samt et enkelt spill (2-like) med brukerinteraksjon og rangering.

---

## Funksjonalitet

###  Brukerregistrering og administrasjon
- Modell: `Bruker` (`Id`, `Navn`, `KontaktInfo`, `AntallSpill`)
- CRUD-generert med scaffolding
- Tilgang via `/Brukers/`

###  Spill: 2-like Memory Game
- Tilgjengelig via `/Home/Spill`
- Fargerike celler: Klikk på to like for å fjerne dem
- Når alle par er funnet:
  - Vises meldingen **"Spillet er ferdig!"**
  - `AntallSpill` for brukeren økes

###  Rangering (ekstra)
- Automatisk toppliste over brukere med flest fullførte spill
- Oppdateres live etter hvert spill (via `fetch` og `HentRangering`-API)

---

##  Hvordan teste prosjektet

1. Klon repoet:
   ```bash
   git clone https://github.com/<brukernavn>/TSDOblig1.git
   cd TSDOblig1
