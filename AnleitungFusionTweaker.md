# Anleitung FusionTweaker #
## Installation ##
Um das Tool und den Service zu nutzen, müßt ihr erst einmal installieren. Dabei kann es möglich sein, daß Microsofts .NET Framework 4 zusätzlich installiert werden muß, falls es nicht schon vorhanden ist.
Bei einer schon vorhandenen Version vom FusionTweaker empfehle ich die vorherige De-Installation.

## Reiter ##
Sobald es gestartet ist, sollte man ein kleines Fenster mit 11 Reitern sehen. Die ersten 8 Reiter stehen für einen Zustand, indem sich die CPU befinden kann, die beiden Reiter mit "NB" zeigen die Einstellungen für die Northbridge/Grafikeinheit (GPU) und der 11te Reiter ist eher für Debug und weitere Informationen nützlich.

http://fusiontweaker.googlecode.com/files/FusionTweakerV105.PNG

## CPU PStates ##
Hier geht es erst einmal nur um die ersten 8 Reiter.
Der jeweils aktive Zustand kann oben direkt neben den Balken gesehen werden. Sie werden P0 .. P7 genannt. P0 ist dabei der schnellste und P7 der langsamste. Je nach Last vom System, wird dynamisch zwischen den Zuständen hin und hergeschaltet, wobei natürlich P7 weniger Strom verbraucht, als P0.

### Spannung ###
Mit dem Tool kann man jetzt die Spannung (CPU VID) für jeden dieser Zustände einzeln verstellen. Weiterhin läßt sich auch der Divider verändern, womit die jeweilige Frequenz pro Zustand einstellbar ist.

Nach einer Änderung, drückt man auf "Apply" rechts unten. Damit werden diese Einstellungen erst einmal temporär übernommen. Überprüft werden kann das mit dem sehr guten Programm CPU-Z.

Als Beispielwerte hier einmal die Einstellungen eines Samsung mit A6-3410MX APU:
  * P0 - 2.3GHz - 1.15V
  * P1 - 1.6GHz - 0.95V
  * P2 - 1.5GHz - 0.925V
  * P3 - 1.4GHz - 0.9V
  * P4 - 1.3GHz - 0.875V
  * P5 - 1.2GHz - 0.8375V
  * P6 - 1.0GHz - 0.8V
  * P7 - 0.8GHz - 0.75V

Damit habe ich einen ca. 10-15% geringeren Verbrauch bei Vollast gemessen, wobei auch die Temperaturen um ca. 5°C sanken.

Wenn das alles klappt, sollte man Prime95 downloaden. Damit kann man einen Stresstest durchführen, um das System auf Stabilität zu testen. Ansonsten können zum Beipiel Blue Screens oder Einfrieren des Rechners vorkommen.

Jeder Zustand sollte einzeln mit dem Stresstest überprüft werden. Das kann man mit den Energie Optionen von Windows erreichen. Während der Stresstests keine wichtige Dateien öffnen, da es bei einem Absturz zu Datenverlust auf geöffneten Dateien kommen kann (allerdings selten).

Sollte das Notebook bei den Tests einfrieren, ist das nicht schlimm. Dann war die Spannung etwas zu niedrig. Einfach lange den Power Knopf drücken und neu mit etwas höherer Spannung probieren (die oben angegebenen Spannungen sollten aber schon relativ sicher sein). Die eingestellten Spannungen im Tool sind noch nirgendwo fest eingestellt.

Sobald alles stabil läuft, **aber auch erst dann**, kann man auf "Service..." klicken. Bitte vorher folgenden Beitrag beachten: ServiceDeaktivieren. Damit kann ein Dienst gestartet werden, der dann beim Windows Start schon dafür sorgt, daß diese modifizierten Spannungen verwendet werden. Dazu einfach auf Update klicken und die Checkbox links aktivieren.

### Frequenz/Divider ###
Wer möchte, kann auch an den Dividern jedes PStates herumstellen, womit sich noch wesentlich geringere Taktfrequenzen erreichen lassen. Zum Beispiel läuft das Notebook auch locker mit 400MHz und einer Spannung von nahe 0.7V. Allerdings ist eine Erhöhung über den Maximaltakt nicht möglich, weil die CPU intern keine niedrigeren Divider übernimmt.
  * Beispiel:
  * E-350 - 1.6GHz
  * FSB 100MHz
  * Multiplier 32x
  * Divider 2
  * Maximaltakt 32/2\*100MHz = 1600MHz
Auch wenn der Divider kleiner als 2 einzustellen geht, wird das von der CPU intern geblockt und nicht verwendet. Die CPU bleibt dann einfach bei 1.6GHz!

## NB PStates ##

### Spannung ###
Da die NB (Northbridge) und die GPU (Grafik) sich zusammen eine Spannungsversorgung teilen, macht es durchaus Sinn auch diese Spannung abzusenken, um eine längere Batterielaufzeit zu erreichen.
Im Grunde sind die Einstellmöglichkeiten sehr ähnlich denen, wie auf der CPU, nur daß man maximal zwei PowerStates zur Verfügung stehen hat.
Bei mir funktionieren folgende Einstellungen:
  * NB P0 - 0.85V
  * NB P1 - 0.8V

Etwas weiter darunter friert bei mir der Bildschirm ein und nur ein langes Drücken des Powerknopfes erweckt das Notebook wieder zum Leben.

### Frequenz/Divider ###
Die Einstellungen des Dividers haben auf der NB bisher keine Funktion.

Wenn dir diese Anwendung gefällt und du willst meine Arbeit unterstützen, kannst du hier spenden.<br>
<a href='https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=MXVAJLM9ABXC4'><img src='https://www.paypal.com/en_US/i/btn/btn_donateCC_LG.gif' /></a>