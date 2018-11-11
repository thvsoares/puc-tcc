docker rm -f $(docker ps -aq -f name=sql)
docker rm -f $(docker ps -aq -f name=backend)
docker run --name sql -d -p 1433:1433 sql
docker run --name backend -d -p 5000:80 backend
