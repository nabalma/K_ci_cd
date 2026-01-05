# 🛰️ KOLYYA - Architecture Fullstack, CI/CD & Messaging

Kolyya est un projet fullstack moderne démontrant la mise en œuvre d'une architecture distribuée intégrant :

- 🔹 Un backend **ASP.NET Core 8**
- 🔹 Un frontend **Angular 21**
- 🔹 Une base de données **PostgreSQL**
- 🔹 Un système de **messagerie RabbitMQ** (via **MassTransit**)
- 🔹 Un pipeline CI/CD avec **GitHub Actions**
- 🔹 Une orchestration via **Docker Compose**

---

## 📦 Fonctionnalités principales

- API RESTful avec endpoints `/api/orders`, `/health`
- Envoi de commandes depuis le frontend
- Publication d’événements RabbitMQ
- Traitement asynchrone par des consumers backend
- Déploiement local en un seul clic via `docker-compose`

---

## 🧱 Structure du projet

```bash
.
├── backEnd/             # Code ASP.NET Core
├── frontEnd/            # Code Angular 21
├── infra/               # Fichiers d'environnement, base de données, RabbitMQ
├── .github/workflows/   # CI/CD Pipelines
├── docker-compose.yml
├── README.md
└── ...
```

---

## 🚀 Démarrer le projet

```bash
docker-compose --env-file infra/env/dev.env up --build
```

👉 Accéder à :
- http://localhost:5000 (API)
- http://localhost:3000 (Frontend Angular)
- http://localhost:15672 (RabbitMQ UI - guest / guest)

---

## 🛑 Arrêter les services

```bash
docker-compose down -v
```

---

## 🧪 Tests manuels

- Envoyer une commande (POST) sur `/api/orders` via Postman ou Angular
- Vérifier dans RabbitMQ que la queue est créée et le message reçu
- Observer les logs backend pour confirmer le traitement du consumer

---

## 🤖 DevOps & CI/CD

- Pipelines CI pour `frontend` & `backend` via GitHub Actions
- Build, test, lint & vérification d'image Docker
- Séparation des environnements (dev, prod)
- Infrastructure déclarée via `docker-compose`

---

## 📬 Communication Asynchrone

Le backend publie des messages via **MassTransit + RabbitMQ**.  
Le consumer (`TouristicCardOrderedConsumer`) traite ces commandes sans bloquer l’API.

---

## 🧠 Auteurs

Projet mené dans le cadre d’un apprentissage DevOps complet.  
Contient des composants modernes, légers et extensibles.

---
