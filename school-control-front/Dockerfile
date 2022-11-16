FROM node:16-alpine as build

WORKDIR /app

COPY package.json /app/

RUN npm set strict-ssl=false
RUN npm install

COPY . /app/

RUN npm run build --prod

FROM nginx:1.17.1-alpine
COPY --from=build /app/dist/school-control-front /usr/share/nginx/html