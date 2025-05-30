# README – mise en place actuelle de la base technique du projet.

!!! (Le readme va changer, il existe pour l'instant pour expliquer ce qui a été fait pour la base du projet pour que se soit clair)
base du projet:
- base backend : dotnet new webapi -n backend
- base frontend : npm create vite@latest frontend -- --template react-ts
- Docker (contenairiser) : DockerFile, Docker Compose, docker-compose up --build  !!!

## Présentation

SUPCHAT est une application de messagerie interne destinée aux entreprises, visant à améliorer la communication et la collaboration entre employés.

Le projet repose sur une architecture fullstack :

- Backend en ASP.NET Core Web API avec Entity Framework Core pour la gestion des données.

- Frontend en React.js (ou Vite/Next.js selon choix final).

- Base de données PostgreSQL (gratuit).

- Contenerisation complète via Docker et orchestration avec Docker Compose.

## Installation

### Prérequis

- .NET 9 SDK (ou version compatible)
- PostgreSQL
- Docker et DOcker Compose installés
- macOS, Windows ou Linux

### 1. Récupérer le projet

Clone le dépôt Git :

```bash
git clone https://github.com/
cd supchatPasserelle
```

### 2. Lancer l'application via Docker

Depuis la racine du projet(où se trouve le fichier docker-compose.yml):

``
docker-compose up --build
``

Cela va :

- Lancer l'API backend sur http://localhost:5000

- Lancer le frontend sur http://localhost:3000

- Créer et démarrer le serveur de base de données PostgreSQL.

Les services communiquent automatiquement grâce aux réseaux définis dans Docker Compose.

### 3. Avancement Actuel

À ce stade, la base technique contient :

## Backend (ASP.NET Core, C#)

- Connexion à la base PostgreSQL configurée.

- Structure propre avec :

  - Controllers/ : Points d'entrée API futurs

  - Models/ : Entités principales (User, Message, etc.)

  - DTOs/ : Objets de transfert de données

  - Services/ : Structure pour la logique métier

  - Data/ : Contexte EF Core (DbContext)

  - Mappings/ : (Automapper / Mapping manuel futur)

  - Middleware/ : (Préparé pour la gestion des erreurs personnalisées)

  - SignalR/ : Dossier prêt pour intégrer la communication temps réel (chat en direct)

  - Dockerfile : Permet de builder et lancer l'API en container.

## Frontend (React.js)

- Création du projet frontend avec :

  - src/ : Arborescence initiale prête pour les pages, composants, services API, hooks personnalisés.

  - Dockerfile : Pour construire et exécuter l’application web en container Nginx.

## Base de données (PostgreSQL)
- Une base de données PostgreSQL est créée automatiquement via Docker.

- Configuration dans docker-compose.yml :

  - Image utilisée : postgres:15

  - Nom du container : supchat_db

- Persistance assurée grâce à un volume Docker (db_data) pour conserver les données même après un arrêt du container.

## Docker Compose
- Définit trois services:
  - backend: API en API.NET Core
  - frontend: Application React
  - base de donnée: PostgreSQL

## Architecture du projet

supchat/
├── backend/
│   ├── Controllers/
│   ├── Data/
│   ├── DTOs/
│   ├── Mappings/
│   ├── Middleware/
│   ├── Migrations/
│   ├── Models/
│   ├── Services/
│   ├── SignalR/
│   ├── Dockerfile
│   └── ...
├── frontend/
│   ├── src/
│   │   ├── assets/
│   │   ├── components/
│   │   ├── pages/
│   │   ├── services/
│   │   ├── hooks/
│   │   └── ...
│   ├── Dockerfile
│   └── ...
├── docker-compose.yml
└── README.md


## Choix techniques

- ASP.NET Core 9 + Entity Framework Core
- React.js avec typescript
- Authentification JWT (prévue)
- Communication temps réel via SignalR (prévu)
- PostgreSQL
- Architecture contenerisée pour faciliter le déploiement
- Séparation stricte Backend/Frontend
- Scalabilité pensée dès la conception
