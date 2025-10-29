FROM node:22-alpine AS build

WORKDIR /app
COPY package*.json /app/

RUN yarn
COPY . /app

RUN yarn build:prod

FROM nginx:alpine
COPY dynamic-env.json /usr/share/nginx/html
COPY nginx.conf  /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/Demo /usr/share/nginx/html
