## Házi feladat — Gráf

Készítsen generikus gráfot a tanultaknak megfelelően majd a következő feladatokat implementálja rajta.

### 1) Statiksztikák

Járja be a gráfot és írja ki, hogy melyik csúcsnak hány szomszédja van és melyek ezek a szomszédok.

Példa bemeneti gráf:

```txt
     A
    /
   B   C
    \ /
     D---E
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
