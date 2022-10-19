FROM node:16 AS build-stage

WORKDIR /app

COPY package*.json /app/

RUN npm install

COPY ./ /app/

ARG configuration=production

RUN npm run build -- --output-path=./dist/out --configuration $configuration

FROM nginx:1.22

COPY --from=build-stage /app/dist/out/ /usr/share/nginx/html