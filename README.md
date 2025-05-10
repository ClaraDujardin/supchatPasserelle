# README – Installation, Lancement et Exemples d’Utilisation

## Présentation

SUPCHAT est 

## Installation

### Prérequis

- .NET 9 SDK (ou version compatible)
- SQL Server (ou LocalDB)
- macOS, Windows ou Linux

### 1. Récupérer le projet

Clone le dépôt Git :

```bash
git clone https://github.com/Paul-Mrsch/3ASPC_Proj.git
cd TaskFlow
```

### 2. Configuration de la base de données

- Vérifie/modifie la chaîne de connexion dans `appsettings.json` :

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskFlowDb;Trusted_Connection=True;"
}
```

### 3. Appliquer les migrations EF Core

```bash
dotnet ef database update
```

### 4. Lancer l’API

```bash
dotnet run
```

L’API sera accessible sur `https://localhost:5001` (ou le port affiché dans la console).

## Documentation Swagger

- Accède à Swagger sur : `https://localhost:5001/swagger`
- Utilise le bouton "Authorize" pour tester les endpoints protégés (JWT).

## Exemples de requêtes

### Inscription

```http
POST /api/user/register
Content-Type: application/json

{
  "name": "Jean Dupont",
  "email": "jean.dupont@email.com",
  "password": "MotDePasse123!"
}
```

### Connexion (récupérer un JWT)

```http
POST /api/user/login
Content-Type: application/json

{
  "email": "jean.dupont@email.com",
  "password": "MotDePasse123!"
}
```

### Créer un projet

```http
POST /api/projects
Authorization: Bearer <votre_token_jwt>
Content-Type: application/json

{
  "name": "Projet SUPINFO",
  "description": "Projet de gestion de tâches pour le cours .NET"
}
```

### Lister les projets

```http
GET /api/projects
Authorization: Bearer <votre_token_jwt>
```

### Créer une tâche

```http
POST /api/tasks
Authorization: Bearer <votre_token_jwt>
Content-Type: application/json

{
  "title": "Faire le rapport",
  "status": "ÀFaire",
  "dueDate": "2025-04-30T23:59:59",
  "commentaires": [ "Commencer par l’intro" ],
  "projectId": 1
}
```

## Architecture du projet

- `Controllers/` : Contrôleurs API REST
- `Models/` : Entités EF Core (User, Project, TaskItem)
- `DTOs/` : Objets de transfert pour l’API
- `Services/` : Logique métier (interfaces + implémentations)
- `Data/` : Contexte EF Core
- `Middleware/` : Gestion des erreurs
- `Helpers/` : JWT, enums, etc.

## Choix techniques

- ASP.NET Core 9, Entity Framework Core, SQL Server
- Authentification JWT
- Swagger (doc auto, exemples, support JWT)
- Séparation claire des responsabilités (services, DTOs, contrôleurs)
