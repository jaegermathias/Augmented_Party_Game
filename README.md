# Augmented_Party_Game
Studentisches Arbeitsprojekt im Modul VRAR an der Hochschule Fulda im Sommersemester 2015.

## Inhalt
* [Projekteinrichtung](#projekteinrichtung)
* [Hinweise zum MatchMaking (BETA)](#hinweise-zum-matchmaking-beta)
* [Branches](#branches)
* [Steuerung](#steuerung)

## Projekteinrichtung
- Sicherstellen, dass die Unity-Version 5.1.1f1 zusammen mit Vuforia 4.2.3 genutzt wird. Keine Updates! Nur diese Kombination scheint für unsere Belange kompatibel! Ich habe die neueren Versionen in jeder Komnbination erfolglos getestet.
- eigenes (altes) lokales Libary-Verzeichnis loeschen
- Immer aus der Szene "Lobby" starten, nicht aus "Game"

## Hinweise zum MatchMaking (BETA)
Unter der Version 5.1.1f1 scheint das MatchMaking ueber das Internet zu funktionieren (Allerdings bislang nicht auf Android).
Da es sich noch immer um eine BETA-Funktion handelt und wir nicht wissen, wie es nach Veroeffentlichung um die Verfuegbarkeit in der Personal Edition von Unity bestellt ist, sollten wir ohnehin i.d.R. auf das lokale Netzwerk setzen.
Auch wenn fuer die Zusammenarbeit im Hochschulnetz die MatchMaker-Funktion hilfreich waere, muessen wir die Funktionalitaet fuer das lokale Netzwerk gewaehrleisten und bestenfalls ein Notebook als Hotspot einsetzen. Zu Präsentationszwecken Geeigneter scheint mir der Einsatz eines mobilen Hotspots über ein Smartphone.

## Branches
Neuer Default-Branch ist der aus Android-Network-Bugfixing entstandene Unterbranch: AP_v0.5. Die anderen Branches dienen nun lediglich der Dokumentation.

## Steuerung
Fuer die Touch-Steuerung bitte Mobile-Input in Unity aktivieren. Für Keyboard- / Gamepad-Steuerung entsprechend deaktiviren. Beim Builden bitte unterscheiden ob ein Gamepad verwendet werden soll oder nicht (aamentlich in der apk). Entsprechenden Build nach Bedarf installieren.
