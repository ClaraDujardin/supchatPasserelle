# README – Supchat B3 Passerelle

# SUPCHAT

SUPCHAT est une application de messagerie interne destinée aux entreprises, visant à améliorer la communication et la collaboration entre employés.

## Sommaire

- [Présentation](#présentation)
- [Fonctionnalités](#fonctionnalités)
- [Architecture du projet](#architecture-du-projet)
- [Technologies utilisées](#technologies-utilisées)
- [Installation et lancement](#installation-et-lancement)
- [Utilisation de l'API](#utilisation-de-lapi)
- [Développement](#développement)
- [Auteurs](#auteurs)

---

## Présentation

SUPCHAT repose sur une architecture fullstack :

- **Backend** : ASP.NET Core Web API avec Entity Framework Core (C#)
- **Frontend** : React.js (Vite, TypeScript, TailwindCSS)
- **Base de données** : PostgreSQL
- **Temps réel** : SignalR pour la messagerie instantanée et les notifications
- **Conteneurisation** : Docker & Docker Compose

---

## Fonctionnalités

- Authentification JWT (inscription, connexion)
- Gestion des utilisateurs et profils (photo, email, etc.)
- Espaces de travail (workspaces) publics/privés
- Canaux de discussion (channels) par workspace
- Messagerie instantanée (texte, fichiers)
- Notifications en temps réel (SignalR)
- Upload de fichiers (messages, profils)
- Interface web responsive (React + TailwindCSS)

---

## Architecture du projet

```
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
│   ├── wwwroot/
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
```

---

## Technologies utilisées

- **Backend** : ASP.NET Core 8/9, Entity Framework Core, SignalR, AutoMapper, JWT, PostgreSQL
- **Frontend** : React 19, Vite, TypeScript, TailwindCSS, Lucide React
- **Base de données** : PostgreSQL 15
- **Conteneurisation** : Docker, Docker Compose
- **Autres** : Nginx (serveur statique frontend), ESLint, AutoMapper

---

## Installation et lancement

### Prérequis

- [.NET SDK 8 ou 9](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/)
- [Docker & Docker Compose](https://www.docker.com/)
- [PostgreSQL](https://www.postgresql.org/) (si hors Docker)

### 1. Cloner le projet

```bash
!!faire bien attention à récuperer le projet dans la branch main pour avoir la version la plus complète et actuelle de notre projet.!!

git clone https://github.com/ClaraDujardin/supchatPasserelle.git
cd supchatPasserelle
```

### 2. Lancer avec Docker Compose

Depuis la racine du projet :

```bash
docker-compose up --build
```

- **Backend** : http://localhost:8080
- **Frontend** : http://localhost (port 80)
- **PostgreSQL** : localhost:5432 (user/pass dans `docker-compose.yml`)

### 3. Lancer manuellement (développement)

#### Backend

```bash
cd backend
dotnet restore
dotnet ef database update # si migrations à appliquer
dotnet run
```

#### Frontend

```bash
cd frontend
npm install
npm run dev
```

---

## Utilisation de l'API

### Authentification

- **Inscription** : `POST /api/users/register`
- **Connexion** : `POST /api/users/login` (retourne un JWT)

### Utilisateurs

- `GET /api/users` (auth requis)
- `POST /api/users/{id}/profile-picture` (upload photo)

### Workspaces

- `GET /api/workspaces` (auth requis)
- `POST /api/workspaces` (création)
- `POST /api/workspaces/{id}/members` (ajout membre)

### Channels

- `GET /api/channels/workspace/{workspaceId}`
- `POST /api/channels`
- `POST /api/channels/{channelId}/members`

### Messages

- `GET /api/messages/channel/{channelId}`
- `POST /api/messages` (envoyer message)

### Notifications

- **Temps réel** via SignalR (`/notificationHub`)
- Test : `POST /api/users/{userId}/test-notif`

---

## Développement

### Backend

- Code C# dans [backend/](backend/)
- Configuration base de données : [backend/appsettings.json](backend/appsettings.json)
- Swagger UI : http://localhost:8080 (en dev)

### Frontend

- Code React/TS dans [frontend/src/](frontend/src/)
- Configuration API : variable d'env `VITE_API_URL`
- Lint : `npm run lint`
- Build : `npm run build`

---

## Auteurs

- Mohamed Coulibaly
- Clara Dujardin
- Rachid Najari
- Assala Amrani

---

## Licence

Projet académique SUPINFO – 2025.  

## Remarques

- Pour toute question contactez l'équipe projet.
- Les migrations EF Core sont déjà prêtes, mais possibilité d'en ajouter avec `dotnet ef migrations add NomMigration`.
- Les images de profil et fichiers sont stockés dans `backend/wwwroot/`.

---

Bon développement sur SUPCHAT !
