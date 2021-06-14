# .NetCoreWebAPI with Redis Caching
Redis Cache Implementation in .NetCore Web API Using Distributed Caching Technique (Redis Docker Instance)

## Redis Cache

Redis is an open-source in-memory data structure store, used as a database, cache.

## Commands to set up Redis Docker Instance

### Pull the docker Redis image from the docker hub

docker pull redis

### Create Redis Container

docker run --name demo_redis_container -p 5003:6379 -d redis

### Start Redis Container

docker start demo_redis_container


<a href="https://www.learmoreseekmore.com/2020/11/dotnetcore-api-redis-cache.html" target="_blank"> Reference </a>
