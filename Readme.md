# .NET & Java - Laboratorium 4

## Opis zadania
Aplikacja webowa w technologii ASP.NET Core

## Technologie

Projekt został wykonany z użyciem następujących technologii:

* **.NET 8**
* **Blazor Web App**
* **Razor Components**
* **Interactive Server Rendering**
* **C#**
* **LINQ**
* **ML.NET**
* **Microsoft.Extensions.ML**
* **Rider**

W projekcie wykorzystano model uczenia maszynowego do klasyfikacji nastroju tekstu. Model analizuje tekst wpisany przez użytkownika i przypisuje mu jedną z kategorii:

* `positive`
* `negative`
* `neutral`



## Trening modelu ML.NET

Model uczenia maszynowego jest trenowany na podstawie pliku CSV z danymi tekstowymi. Dane zawierają tekst oraz przypisany do niego nastrój.

Przykładowy format danych:

```csv
textID,text,selected_text,sentiment,Time of Tweet,Age of User,Country,Population -2020,Land Area (Km²),Density (P/Km²)
cb774db0d1,"I`d have responded, if I were going","I`d have responded, if I were going",neutral,morning,0-20,Afghanistan,38928346,652860,60
549e992a42,Sooo SAD I will miss you here in San Diego!!!,Sooo SAD,negative,noon,21-30,Albania,2877797,27400,105
6e0c6d75b1,2am feedings for the baby are fun when he is all smiles and coos,fun,positive,morning,0-20,Argentina,45195774,2736690,17
```

W projekcie wykorzystywane są głównie dwie kolumny:

* `text` — tekst wpisu,
* `sentiment` — etykieta nastroju.

Model jest trenowany za pomocą ML.NET i zapisywany do pliku:

```text
ML/sentiment-model.zip
```

## Ważne: trening modelu wykonuje się tylko raz

Trening modelu należy wykonać tylko raz, aby wygenerować plik:

```text
ML/sentiment-model.zip
```

Po wygenerowaniu pliku modelu należy zakomentować lub usunąć wywołanie trenowania modelu w `Program.cs`.

Przykład wywołania używanego tylko do treningu:

```csharp
SentimentModelTrainer.Train();
```

Po poprawnym wygenerowaniu pliku `.zip` powinno zostać zakomentowane:

```csharp
// SentimentModelTrainer.Train();
```

Dzięki temu aplikacja przy kolejnych uruchomieniach nie będzie trenowała modelu od nowa, tylko użyje już istniejącego pliku:

```text
ML/sentiment-model.zip
```

## Uruchomienie projektu na Windows

### 1. Wymagania

Przed uruchomieniem projektu należy zainstalować:

* .NET SDK 8.0 lub nowszy,
* Rider albo Visual Studio,
* Git.

Sprawdzenie wersji .NET:

```bash
dotnet --version
```

### 2. Sklonowanie repozytorium

```bash
git clone https://github.com/matroxok/.NET_LAB4.git
cd .NET_LAB4
```

### 3. Przywrócenie paczek NuGet

```bash
dotnet restore
```

### 4. Uruchomienie aplikacji

```bash
dotnet run
```


## Uruchomienie projektu na macOS / Linux

### 1. Wymagania

Przed uruchomieniem projektu należy zainstalować:

* .NET SDK 8.0 lub nowszy,
* Git,
* Rider, Visual Studio Code albo inne IDE obsługujące .NET.

Sprawdzenie wersji .NET:

```bash
dotnet --version
```

### 2. Sklonowanie repozytorium

```bash
git clone https://github.com/matroxok/.NET_LAB4.git
cd .NET_LAB4
```

### 3. Przywrócenie zależności

```bash
dotnet restore
```

### 4. Uruchomienie aplikacji

```bash
dotnet run
```

Aplikacja zostanie uruchomiona lokalnie. Adres będzie widoczny w terminalu, np.:

```text
http://localhost:5000
https://localhost:5001
```

## Instalacja paczek ML.NET

Jeżeli projekt nie ma jeszcze zainstalowanych paczek ML.NET, można je dodać poleceniami:

```bash
dotnet add package Microsoft.ML
dotnet add package Microsoft.ML.FastTree
dotnet add package Microsoft.Extensions.ML
```

Po dodaniu paczek należy wykonać:

```bash
dotnet restore
```

## Działanie aplikacji

Aplikacja zawiera stronę pogodową oraz stronę do analizy nastroju.

### Strona Weather

Strona pogodowa generuje przykładowe dane pogodowe, takie jak:

* data,
* temperatura w stopniach Celsjusza,
* temperatura w stopniach Fahrenheita,
* opis pogody.

Dodatkowo umożliwia filtrowanie danych, np. według temperatury lub nazwy opisu pogody.

### Strona Analizy nastrouju AI

Strona analizy nastroju pozwala użytkownikowi wpisać tekst, a następnie uruchomić klasyfikację za pomocą wytrenowanego modelu ML.NET.

Przykładowe teksty do sprawdzenia:

```text
I am very happy today
```

```text
I hate this day
```

Po kliknięciu przycisku aplikacja wyświetla przewidywany nastrój tekstu, np.:

```text
positive
negative
neutral
```

## Uwagi

Model ML.NET nie powinien być trenowany przy każdym uruchomieniu aplikacji. Trening jest procesem jednorazowym, którego wynikiem jest plik `.zip` z zapisanym modelem.

Po wygenerowaniu modelu aplikacja korzysta z gotowego pliku:

```text
ML/sentiment-model.zip
```

Jeżeli plik modelu zostanie usunięty, należy ponownie odkomentować trenowanie modelu, uruchomić aplikację w celu wygenerowania nowego modelu, a następnie ponownie zakomentować trenowanie.
