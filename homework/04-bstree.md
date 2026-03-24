## Házi feladat — Bináris keresőfa

Készítsen generikus bináris keresőfát a tanultaknak megfelelően majd a következő feladatokat implementálja rajta.

### 1) Statiksztikák

Készítsen egy `TreeStatistics` osztályt, amely metódusai megkapják a generikus bináris keresőfákat, és a következőket határozzák meg:

- fa magasság: mi a fa magassága
- csúcsok száma: hány csúcsa van
- levelek száma: hány levele van
- min: mi a legkisebb elem értéke
- max: mi a legnagyobb elem értéke
<br>

---

<br>

### 2) Tömb rendezés

Generáljon egy tetszőleges tömböt, amelyből építsen fel bináris keresőfát, majd a fát a megfelelő bejárással feldolgozva adja vissza rendezetten az elemeket az eredeti tömbbe.

### 3) Szótár alkalmazás

Készítsen egy olyan konzolos alkalmazást, amely egy **angol–magyar szótárat valósít meg bináris keresőfa segítségével**. A program minden szótári bejegyzésnél tárolja az angol szót és a hozzá tartozó magyar fordítást. A bináris keresőfában az elemeket az angol szó szerint kell elhelyezni.

Feladatok:

- Készítsen metódust, amely adott kezdőbetű szerint listázza a szópárokat.
- Lehessen egy adott angol szóhoz tartozó magyar fordítást frissíteni.
- Lehessen csak a magyar vagy csak az angol szavakat listázni.
- JSON fájlba szerializálja ki a szótár tartalmát a lentebbi mintának megfelelően:

```json
[
    { "eng": "apple", "hun": "alma"   },
    { "eng": "cat",   "hun": "macska" }
]
```

### 4) ESport rangsor

Készítsen **rendezett láncolt lista** és **bináris keresőfa** segítségével egy csapatok eltárolására alkalmas rendszert. Mind a két adatszerkezetet **generikusan** valósítsa meg.

A csapatok résztvevőit `Player` objektumokkal képezze le a következő tulajdonságokkal:

- `id`: a játékos azonosítója
- `name`: a játékos neve
- `score`: a játékos pontszáma

A csapatokat listával képezze le, ahol a játékosok pontszáma alapján történjen a beszúrás logikája.

Az összeállított csapatokat bináris keresőfában tárolja el. Minden csapatnak készítsen egy algoritmus alapján valamilyen egyedi azonosítót, ami alapján a fába való beszúrás megtörténik.

Járja be a fát és írja ki a csapatokat a konzolra.

### 5) Fa struktúra megjelenítése vizuálisan

Készítsen egy olyan vizuális megjelenítést a bináris keresőfához, amely szintenként írja ki az elemeket a konzolra, egy minta alább látható.

Fa felépítése:

```txt
gyökér: 20 - alma
balra: 10 - szilva
jobbra: 22 - barack
10 balra: 9 - eper
22 jobbra: 31 - narancs
```

Szintenkénti konzolos megjelenítés, hiányzó gyerek elemekkel:

```txt
0. szint: 20 - alma
1. szint: 10 - szilva | 22 - barack
2. szint: 9 - eper | - | - | 31 - narancs
```

Fa-szerű megjelenítés, hiányzó gyerekelemek nélkül:

```txt
                20 - alma
        10 - szilva      22 - barack
    9 - eper                 31 - narancs
```
