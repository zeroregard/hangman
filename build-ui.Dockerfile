FROM node:alpine as build

WORKDIR /app

COPY ./hangman-ui/package.json ./

RUN npm install

COPY ./hangman-ui .

RUN npm install -g @angular/cli@8.3.2
RUN cd /app && npm install
COPY ./hangman-ui /app
RUN cd /app && npm run build

FROM nginx:alpine

COPY --from=build /app/dist/* /usr/share/nginx/html/
COPY ./hangman-ui/src/nginx.conf /usr/share/nginx/html/nginx.conf

CMD ["nginx", "-c", "/usr/share/nginx/html/nginx.conf"]