# Fototoestellen (EF Core Code First)

> [!NOTE]
> Dit is een mogelijke oplossing voor **Fase 1** van de oefening.

## Aandachtspunten
- Console app die gebruik maakt van ApplicationBuilder
  - Settings binden
  - Dependency injection
  - App lifecycle (run/stop)
- Bevat relatief uitgebreide CUI.
- Service interface en implementatie in zelfde file gezien er slechts één is (op dit moment).
- Service geeft tuples terug i.p.v. expliciete DTO-types. Het is eens iets anders.
- Solution geeft 2 warnings. Deze zijn afkomstig uit bestanden gegenereerd door EF Core, dus dat is ok.

## Potentiële Verbeteringen
- Er is nu geen controle op de **range** van input waarden.
