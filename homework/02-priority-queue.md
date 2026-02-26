## Házi feladat — Prioritási sor belső tömbbel

**Feladat:** Valósítson meg egy `ArrayPriorityQueue<T>` nevű **generikus prioritási sort**, amely **belső tömböt** használ tárolásra. Az elemeket prioritás alapján kell kiszolgálni, azonos prioritás esetén pedig **FIFO** sorrendet kell tartani.

## 1) Cél

A feladat célja, hogy gyakorolja:

* generikus osztály készítését
* generikus típusokkal való dolgozást
* a sor adatszerkezetet
* prioritás alapú kiválasztást / rendezett beszúrást

## 2) Követelmények (specifikáció)

### 2.1 Alapelv

* Minden elemhez tartozik egy `int priority`.
* **Nagyobb priority** = **előbb kerül sorra** (max-priority queue).
* **Azonos prioritás** esetén az elem, amelyik **korábban lett beszúrva**, előbb jöjjön ki (**FIFO / stabil működés**).

### 2.2 Osztály deklaráció

Valósítsa meg az alábbi osztályt és tagokat:

```csharp
public class ArrayPriorityQueue<T>
{
    // Belső elem-típus (egy sorban tárolt rekord)
    private struct Entry
    {
        public T Item;
        public int Priority;
        public long Order;

        public Entry(T item, int priority, long order)
        {
            Item = item;
            Priority = priority;
            Order = order;
        }
    }

    // A belső tömb
    private Entry[] items;

    // Hány elem van ténylegesen a tömbből használatban
    private int count;

    // FIFO azonos prioritásnál: beszúrási sorszám
    private long orderCounter;

    public int Count => count;
    public bool IsEmpty => count == 0;

    public ArrayPriorityQueue(int capacity = 4)
    {
        if (capacity < 1) capacity = 4;
        items = new Entry[capacity];
        count = 0;
        orderCounter = 0;
    }

    public void Enqueue(T item, int priority)
    {
        // ...
    }

    public T Dequeue()
    {
        // ...
    }

    public (T Item, int Priority) Peek()
    {
        // ...
    }

    public bool TryDequeue(out T value, out int priority)
    {
        // ...
    }

    public void Clear()
    {
        // ...
    }
}
```

### 2.3 Belső tárolás: tömb + rekord (Entry)

Az elemek tárolását a belső tömbben végezze, melyhez használja fel az `Entry` típust.

A belső struct/class (**nested type**) olyan segéd-típus, amit csak a befoglaló osztály használ belső adatreprezentációra, így elrejti a megvalósítás részleteit a külvilág elől (jobb egységbezárás (encapsulation)), és rendezetten, célzottan kezeli az osztályon belüli "csomagolt" adatokat.

### 2.4 Működés és algoritmus

Két megoldással is megoldható a feladat, javasolt mind a kettőt elkészíteni a gyakorlás miatt.

#### Opció A — Rendezetlen tömb + keresés Dequeue-nál

* `Enqueue`: a tömb végére ír (O(1) amortizált)
* `Dequeue`: megkeresi a **legnagyobb prioritású** elemet; holtversenyben a **legkisebb Order** nyer (FIFO)
* a kivett elemet törölje úgy, hogy a tömb “lyuk” nélkül maradjon (pl. **balra csúsztatással**)

#### Opció B — Rendezett beszúrás (stabil)

* `Enqueue`: beszúráskor keresse meg a helyét és csúsztassa jobbra a többit (O(n))
* a tömb eleje mindig a “legjobb” elem (legnagyobb priority, FIFO)
* `Dequeue`: az első elemet adja vissza (O(n) a csúsztatás miatt, vagy használhat head indexet)

> Bármelyik megoldást választja: **a belső tárolás tömb legyen**, és legyen **kapacitásnövelés**.

### 2.5 Kapacitásnövelés (Grow)

Ha a tömb megtelt, növelje a kapacitást (pl. duplázás), tehát hozzon létre nagyobb tömböt és másolja át az elemeket

### 2.6 Hibakezelés

* `Dequeue()` és `Peek()` üres sor esetén dobjon `InvalidOperationException`-t `"PriorityQueue is empty."` üzenettel.
* `TryDequeue`:

  * ha üres: `false`, `value = default`, `priority = 0`
  * ha nem üres: `true` és adja vissza a kivett elemet és prioritását

## 3) Kötelező tesztesetek (konzol program)

Készítsen `Program.cs`-ben demonstrációt `ArrayPriorityQueue<string>` típusra.

### 3.1 Beszúrás

Szúrja be az alábbi elemeket **ebben a sorrendben**:

* `"A"` priority 1
* `"B"` priority 5
* `"C"` priority 3
* `"D"` priority 5
* `"E"` priority 2
* `"F"` priority 5

### 3.2 Elvárt kiszolgálási sorrend (FIFO azonos prioritásnál)

`Dequeue`-k eredménye:

1. `"B"` (5)
2. `"D"` (5)
3. `"F"` (5)
4. `"C"` (3)
5. `"E"` (2)
6. `"A"` (1)

### 3.3 Üres esetek demonstrációja

* Miután kiürült:

  * egyszer hívja meg a `TryDequeue`-t (ne dobjon kivételt)
  * egyszer hívja meg a `Dequeue()`-t (dobjon kivételt)
  * egyszer hívja meg a `Peek()`-et (dobjon kivételt)

## 4) Kimenet forma (javaslat)

A konzolra írjon ki ilyen jellegű sorokat:

* `Enqueue("B", 5), Count: 2`
* `Peek() -> ("B", 5)`
* `Dequeue() -> "B" (priority: 5), Count: 5`
* `TryDequeue -> false`
