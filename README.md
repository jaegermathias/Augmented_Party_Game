# Augmented_Party_Game
Studentisches Arbeitsprojekt im Modul VRAR an der Hochschule Fulda im Sommersemester 2015.

## Inhalt
* [Projekteinrichtung](#projekteinrichtung)
* [Hinweise zum MatchMaking (BETA)](#hinweise-zum-matchmaking-beta)
* [Branch: Master](#vorgehensweise-beim-testen)
* [Branch: Android_Network-Bugfix](#branch-android_network-bugfix)


## Projekteinrichtung
- Sicherstellen, dass die Unity-Version 5.1.1f1 zusammen mit Vuforia 4.2.3 genutzt wird. Keine Updates! Nur diese Kombination scheint für unsere Belange kompatibel! Ich habe die neueren Versionen in jeder Komnbination erfolglos getestet.
- Immer aus der Szene "Lobby" starten, nicht aus "Game"

## Hinweise zum MatchMaking (BETA)
Unter der Version 5.1.1f1 scheint das MatchMaking ueber das Internet zu funktionieren (Allerdings bislang nicht auf Android).
Da es sich noch immer um eine BETA-Funktion handelt und wir nicht wissen, wie es nach Veroeffentlichung um die Verfuegbarkeit in der Personal Edition von Unity bestellt ist, sollten wir ohnehin i.d.R. auf das lokale Netzwerk setzen.
Auch wenn fuer die Zusammenarbeit im Hochschulnetz die MatchMaker-Funktion hilfreich waere, muessen wir die Funktionalitaet fuer das lokale Netzwerk gewaehrleisten und bestenfalls ein Notebook als Hotspot einsetzen.


## Branch: Master
Aktuell gibt es auf dem Master-Branch Netzwerk-Schwierigkeiten, deren Ursache noch nicht geklaert wurde.

## Branch: Android_Network-Bugfix
@jaegermathias : Arbeite gerade auf diesem Branch, um die Netzwerk-Probleme zu debuggen.

Was scheinbar nach dem synchronisieren getan werden muss:
- (altes) lokales Libary-Verzeichnis loeschen

Hinweis: Ein Multiplayer-Spiel mit Spawnpositionen fuer jeden Spieler funktioniert zwischen meinem Notebook, meinem Android-Tablet, Sebs Android-Smartphone und PC.
