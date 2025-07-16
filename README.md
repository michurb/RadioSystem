# System do zarządziania audycjiami radiowymi

## Struktura projektu

Projekt System Harmonogramowania Radia jest zbudowany na bazie architektury warstwowej:
- Api: Warstwa prezentacji, obsługuje żądania HTTP
- Application: Warstwa aplikacji zawierająca logikę biznesową
- Infrastructure: Warstwa infrastruktury obejmująca dostęp do bazy danych.
- Domain: Warstwa domeny z modelami biznesowymi

## Aby uruchomić aplikację lokalnie
### Wymagania:
- .NET 8

1. Sklonuj repozytorium
2. Przejdź do głównego katalogu
3. uruchom aplikację komendą
```
dotnet build
dotnet run --project src/RadioSchedulingSystem.Ap
```

## Uruchomienie za pomocą Docker
### Wymagania:
- Docker

Używając pliku compose:
```
docker compose up -d
```

## Przykładowe zapytania

Pobieranie audycji za pomocą ID
```
curl -X GET "http://localhost:5000/api/shows/3fa85f64-5717-4562-b3fc-2c963f66afa6" -H "accept: application/json"
```

Pobieranie dziennego raportu
```
curl -X GET "http://localhost:5000/api/shows/daily-report?date=2025-10-15" -H "accept: application/json
```

Tworzenie nowej audycji
```
curl -X POST "http://localhost:5000/api/shows" -H "Content-Type: application/json" -d '{"dto": {"title": "Wiadomości", "startTime": "2025-10-15T12:00:00", "duration": 30}}'
```
