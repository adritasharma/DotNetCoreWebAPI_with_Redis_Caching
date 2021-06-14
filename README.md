# .NetCoreWebAPI with Redis Caching
Redis Cache Implementation in .NetCore Web API Using Distributed Caching Technique (Redis Docker Instance)

## Redis Cache

Redis is an open-source in-memory data structure store, used as a database, cache.

## Commands to set up Redis Docker Instance

### Pull the docker Redis image from the docker hub

docker pull redis

### Create Redis Container

docker run --name adrita_redis_container -p 5003:6379 -d redis

### Start Redis Container

docker start adrita_redis_container


<a hreh="https://www.learmoreseekmore.com/2020/11/dotnetcore-api-redis-cache.html"> Reference </a>
