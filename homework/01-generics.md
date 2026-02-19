## Házi feladat — Validátoros generikus osztály

**Feladat:** Valósítson meg egy `ValidatedValue<T>` nevű **generikus osztályt**, amely egy `T` típusú értéket tárol, és biztosítja, hogy az érték csak akkor legyen beállítható, ha megfelel egy megadott validációs feltételnek.

### 1) Osztály célja

Az osztály egyetlen értéket kezel:

* rendelkezik egy aktuális értékkel (`Value`)
* rendelkezik egy validátor függvénnyel (`Func<T, bool> validator`)
* csak olyan új értéket fogad el, amelyre a validátor `true`-t ad

## 2) Követelmények (specifikáció)

### 2.1 Osztály deklaráció

Valósítson meg egy generikus osztályt az alábbi névvel és tagokkal:

```csharp
public class ValidatedValue<T>
{
    public T Value { get; private set; }

    public ValidatedValue(T initialValue, Func<T, bool> validator)
    {
        // ...
    }

    public bool TrySet(T newValue)
    {
        // ...
    }
}
```

### 2.2 `Value` tulajdonság

* `Value` legyen **publikus olvasható**, de **kívülről ne legyen közvetlenül írható**.
* Az érték módosítása kizárólag a `TrySet` metóduson keresztül történhessen.

### 2.3 Konstruktor működése

A konstruktor paraméterei:

* `initialValue` – a kezdő érték
* `validator` – egy függvény, amely eldönti, hogy egy `T` érték érvényes-e

**Elvárás:**

* Ha `validator` `null`, dobjon `ArgumentNullException` kivételt.
* Ha `initialValue` **nem felel meg** a validátornak, dobjon `ArgumentException` kivételt (pl. “Initial value is invalid” üzenettel).
* Ha megfelel, akkor `Value` vegye fel az `initialValue` értékét.

### 2.4 `TrySet` metódus működése

A `TrySet(T newValue)` metódus:

* lefuttatja a validátort az `newValue`-ra
* ha a validátor `true`:

  * állítsa be `Value = newValue`
  * térjen vissza `true`-val
* ha a validátor `false`:

  * **ne változtassa meg** a `Value`-t
  * térjen vissza `false`-szal

## 3) Kötelező tesztesetek (konzol program)

Készítsen `Program.cs`-ben demonstrációt, amely **mindhárom** típusra létrehoz egy példányt, és minden példánynál legalább:

* **2 sikeres** `TrySet`
* **2 sikertelen** `TrySet`
  hívást végez, és kiírja:
* a `TrySet` visszatérési értékét
* a `Value` aktuális értékét

### 3.1 `int` validálás: csak pozitív

* Validátor: `x > 0`
* Példa érvényes: `1`, `50`
* Példa érvénytelen: `0`, `-3`

### 3.2 `string` validálás: nem lehet null/üres/whitespace

* Validátor: `!string.IsNullOrWhiteSpace(x)`
* Példa érvényes: `"alma"`, `"OK"`
* Példa érvénytelen: `""`, `"   "`
  *(extra: próbálja ki `null`-lal is, ha szeretné)*

### 3.3 `DateTime` validálás: nem lehet jövőbeli dátum

* Validátor: `x <= DateTime.Now`
* Példa érvényes: `DateTime.Now`, `DateTime.Now.AddDays(-1)`
* Példa érvénytelen: `DateTime.Now.AddMinutes(5)`, `DateTime.Now.AddDays(1)`

## 4) Kimenet forma (javaslat)

A konzolra például ilyen jellegű sorokat írjon:

* `TrySet(…) -> true, Value: …`
* `TrySet(…) -> false, Value: …`
