# Utilise une image Node.js officielle pour builder l'app
FROM node:20 AS build
WORKDIR /app

# Copie des fichiers de dépendances
COPY package*.json ./
RUN npm install

# Copie du reste du code source
COPY . .

# Build de l'application (modifie 'build' si ton script est différent)
RUN npm run build

# Utilise Nginx pour servir l'app en production
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Suppression des fichiers par défaut de Nginx
RUN rm -rf ./*

# Copie des fichiers buildés
COPY --from=build /app/dist .

# (Optionnel) Copie d'une config Nginx personnalisée
# COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
