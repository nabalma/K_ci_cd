# =========================
# Étape 1 : Build Angular
# =========================
FROM node:20 AS builder

WORKDIR /app

COPY package*.json ./
RUN npm ci

COPY . .
RUN npm run build

# =========================
# Étape 2 : Nginx
# =========================
FROM nginx:alpine

# ⚠️ Angular 21 → sortie directe dans dist/kolyya-frontend
COPY --from=builder /app/dist/kolyya-frontend/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
