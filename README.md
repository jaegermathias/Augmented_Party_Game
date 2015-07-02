# Augmented_Party_Game
Studentisches Arbeitsprojekt im Modul VRAR an der Hochschule Fulda im Sommersemester 2015.

## Inhalt
[Vorgehensweise beim Testen](# Vorgehensweise beim Testen)

## Vorgehensweise beim Testen
- Sicherstellen, dass die aktuelle Unity-Version genutzt wird (5.1.1f1)
- Immer aus der Lobby starten, nicht aus der Spielszene

## Hinweise zum MatchMaking (BETA)
Unter der Version 5.1.1f1 scheint das MatchMaking ueber das Internet zu funktionieren.
Da es sich jedoch noch immer um eine BETA-Funktion handelt und wir nicht wissen, wie es nach Veroeffentlichung um die Verfuegbarkeit in der Personal Edition von Unity bestellt ist, sollten wir i.d.R. auf das lokale Netzwerk setzen.
Auch wenn fuer die Zusammenarbeit im Hochschulnetz die MatchMaker-Funktion hilfreich waere, muessen wir die Funktionalitaet fuer das lokale Netzwerk gewaehrleisten und bestenfalls ein Notebook als Hotspot einsetzen.


## Branch: Master
Aktuell gibt es auf dem Master-Branch Netzwerk-Schwierigkeiten, deren Ursache noch nicht geklaert wurde.

## Branch: Android_Network-Bugfix
@jaegermathias : Arbeite gerade auf diesem Branch, um die Netzwerk-Probleme zu debuggen.

Was scheinbar nach dem synchronisieren getan werden muss:
- (altes) lokales Libary-Verzeichnis loeschen

Hinweis: Ein Multiplayer-Spiel mit Spawnpositionen fuer jeden Spieler funktioniert zwischen meinem Notebook, meinem Android-Tablet und Sebs Android-Smartphone.

Es funktioniert im selben Setting nicht: Sebs PC.
