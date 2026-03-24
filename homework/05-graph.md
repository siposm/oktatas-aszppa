## Házi feladat — Gráf

Készítsen generikus gráfot a tanultaknak megfelelően majd a következő feladatokat implementálja rajta.

### 1) Statiksztikák

Járja be a gráfot és írja ki, hogy melyik csúcsnak hány szomszédja van és melyek ezek a szomszédok.

Példa bemeneti gráf:

```txt
   A --- B   C
          \ /
           D --- E
```

Élek: A-B, B-D, C-D, D-E

Példa kimenet:

- A - 1 db szomszéd: B
- B - 2 db szomszéd: A, D
- C - 1 db szomszéd: D
- D - 3 db szomszéd: B, C, E
- E - 1 db szomszéd: D

### 2) Összefüggőség vizsgálat

Döntse el DFS vagy BFS segítségével, hogy egy gráf összefüggő-e. Induljon el egy tetszőleges csúcsból, ha minden csúcs érintésre kerül akkor a gráf összefüggő, egyéb esetben nem.

### 3) Kör keresése

Döntse el egy gráfról, hogy tartalmaz-e kört. DFS bejárás közben figyelje, hogy egy már bejárt szomszéd nem a szülőcsúcs-e.

### 4) Közösségi hálózat

Képezze le a facebook / instagram ismerőseit közösségi hálóra, gráf segítségével. Adja hozzá a gráfhoz a csúcsokat (ismerősei), valamint az éleket (ki kit ismer). Kevés adat esetén AI-val generáljon további adatokat.

- Legyen lehetőség lekérdezni egy adott személy ismerőseit.
- Legyen lehetőség "ismerősnek jelölést" készíteni, amelyhez az kell, hogy két személy között legyen legalább 2 db közös ismerős.

### 5) Látványosságok

Készítsen egy térképet ahol városokat lehet rögzíteni, a városokhoz pedig nevezetességek társíthatók. A térképet gráffal reprezentálja, ahol a csomópontok a városok, a városban található nevezetességek pedig láncolt listával vannak megvalósítva. A megvalósításhoz használjon generikus gráf és generikus láncolt lista adatszerkezeteket.

> [!IMPORTANT]
> A feladat megvalósítható számos módon. Például elfogadható, ha a generikus adatszerkezeteket így használja: `MyGraph<MyList<MyClass>>`, ebben az esetben a városok nevét külön el kell valahogy tárolni, és társítani hozzá az adott láncolt listát a gráfon belül. Az is elfogadható, ha egy `City` wrapper osztályt létrehoz, amiben helyet foglal a város neve valamint a láncolt listában lévő nevezetességek. Ekkor `Graph<City>` formában lesz a példányosítás. Ezen kívül más megvalósításnak is van létjogosultsága. Gyakorlásnak javasolt több módszerrel is megoldani a feladatot!

Tetszőleges algoritmussal járja be a gráfot, és írja ki a városokat a hozzájuk tartozó nevezetességekkel.

Példa kimenet:

- Párizs – Eiffel-torony, Louvre, Notre-Dame
- Róma – Colosseum, Forum Romanum, Pantheon, Trevi-kút, Szent Péter-bazilika
- London – Big Ben, Tower Bridge, Buckingham-palota, London Eye, Tower of London
- Barcelona – Sagrada Família, Casa Batlló
- Athén – Akropolisz, Parthenón, Akropolisz Múzeum, Zeusz temploma, Panathenaiko Stadion
- Prága – Károly híd, Prágai vár

---

Egészítse ki a feladatot úgy, hogy a városok között távolságot is lehessen megadni, km mértékegységben. Tetszőleges bájárással dolgozza fel a városokat, majd ezt írja ki őket a nevezetességekkel együtt, pluszban kiegészítve a távolságokkal. A távolságok számításához megfelelő ha készít egy metódust, ami A-B csúcs közötti távolságot adja vissza, de más megoldás is elfogadható. A végén írja ki a teljes út hosszát is.

Példa kimenet:

- Párizs (0 km) – Eiffel-torony, Louvre, Notre-Dame
- Róma (1500 km) – Colosseum, Forum Romanum, Pantheon, Trevi-kút, Szent Péter-bazilika
- London (1900 km) – Big Ben, Tower Bridge, Buckingham-palota, London Eye, Tower of London
- ...
- Teljes út hossza: 0 + 1500 + 1900 + ... = y km
