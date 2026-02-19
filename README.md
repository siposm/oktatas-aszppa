# Adatszerkezetek és Párhuzamos Programozás Alapjai

TTK: <https://nik.uni-obuda.hu/targyleirasok/tantargyak/adatszerkezetek-es-parhuzamos-programozas-alapjai/>

## Heti menetrend

| Hét | Témakör |
|---:|---|
| 1 | Követelmények, Generikus típusok |
| 2 | Sor és verem |
| 3 | Láncolt lista |
| 4 | *Elmarad* |
| 5 | Bináris keresőfa |
| 6 | Gráfok |
| 7 | *Rektori szünet* |
| 8 | **Zárthelyi dolgozat I.** |
| 9 | Párhuzamos programozás I. |
| 10 | Párhuzamos programozás II. |
| 11 | Párhuzamos programozás III. |
| 12 | **Zárthelyi dolgozat II.** |
| 13 | Konzultáció |
| 14 | Pótló zárthelyi dolgozat |

## Parancsok

    // új projekt létrehozása a mappa neve alapján
    mkdir foldername
    cd foldername
    dotnet new console --use-program-main

    // sln létrehozása dotnet10-es slnx formátumban
    dotnet new sln -n oktatas-aszppa --format slnx

    // gitignore létrehozása
    dotnet new gitignore

    // meglévő projekt (csproj) hozzáadása sln-hez
    dotnet sln oktatas-aszppa.slnx add 01-generics/01-generics.csproj
    dotnet sln oktatas-aszppa.slnx add 02-linked-list/02-linked-list.csproj
