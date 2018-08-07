FROM node:10.6-alpine AS builder
WORKDIR /app

COPY package*.json ./
RUN npm i
RUN ls -l

COPY . .
RUN npm run build -- --prod
RUN ls -l
RUN ls -l ./dist

FROM nginx:1.15-alpine AS http
COPY --from=builder /app/dist/ui /usr/share/nginx/html
