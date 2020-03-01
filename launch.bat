echo building backend
docker build -f ./build-api.Dockerfile -t hangman-api .
echo running backend
docker run -d -p 8887:80 --name hangman-api hangman-api:latest

echo building frontend
docker build -f ./build-ui.Dockerfile -t hangman-ui .
echo running frontend
docker run -d -p 8888:80 --name hangman-ui hangman-ui:latest
