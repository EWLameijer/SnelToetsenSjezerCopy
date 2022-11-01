# SnelToetsenSjezer
Application to practise usage of Hot Keys  
  
-------------  
  
### STATUS:  
Na een paar re-factors etc hebben we momenteel een werkende applicatie:  
- Maakt gebruik van een extern XML bestand met sneltoetsen  
- Er is ondersteuning voor meerdere oplossingen per sneltoets-vraag  
- Een oplossing kan een string bevatten zodat snel typen geen probleem zou moeten zijn (werkt nog niet helemaal goed???)  
  
-------------  
  
### TODO:  
  
#### MainMenuForm:  
- [ ] Knoppen voor min/max aantal vragen (en misschien ook 5/10/15/20/25?)  
- [ ] Taal keuze? (zie "Code/Meerdere formulieren" deel van de todo)  
  
#### GameForm:  
- [ ] Een devider & label voor de input-visualizatie aan de onderkant van het GameForm & die input-visualisatie niet meer updaten als vraag al goed/fout gekeurd is  
  
#### Game over:  
- [ ] Minder lelijke interface (heb nu met panels een eigen soort-van-grid opgebouwd maar waarom gebruik ik niet gewoon DataGridView???)  
- [ ] Als je de laatste vraag goed hebt is "get ready for next question" overbodig  
  
#### Code/Meerdere formulieren:  
- [ ] String input gaat nog steeds niet helemaal lekker? "prop,Tab,Tab" is irritant, als je meerdere tekens tegelijk in drukt gaat het soms wel en soms niet goed?? DIT UITGEBREID TESTEN!!!  
- [ ] Toetsen-Vertaling (ControlKey naar Ctrl, Oem5 naar \, etc) aan de hand van een xml bestandje  
- [ ] Programma-Vertaling (er is momenteel een combinatie van engelse interface en nederlandse vragen, maak in main menu een taal keuze?) aan de hand van een xml bestandje  
- [ ] Er word nu gebruik gemaakt van hele secondes, waarom niet wat cijfers achter de komma?  
- [ ] Testen!  
- [ ] Nog meer testen!!!  
