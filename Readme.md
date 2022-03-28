# Implements Microservice and Event Sourcing in .net 5


 ## Autamation Build & Deploy :

[![.NET Build and  Run  Tests](https://github.com/Alibesharat/Customers-microservice/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Alibesharat/Customers-microservice/actions/workflows/dotnet.yml)

[![CustomerApp - Build and Push to DockerHub](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.customer.yml/badge.svg)](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.customer.yml)

[![OrderApp - Build and Push to DockerHub](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.order.yml/badge.svg)](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.order.yml)

[![api - Build and Push to DockerHub](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.api.yml/badge.svg)](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.api.yml)



 ## Technologies


|                |                       |
|------------------------|-------------------------------|
|`Langauge` |C#                 
|`Framework`|.Net5                 
|`validation`|[FluentValidation](https://github.com/FluentValidation/FluentValidation)
|`Mapping`|[Mapster](https://github.com/MapsterMapper/Mapster)
|`Sync Communication`|[Model First Grpc ](https://github.com/protobuf-net/protobuf-net.Grpc)                    
|`Async Communication (MessageBroker)`| Kafka
|`Storage`|[EvnetStoreDb](https://hub.docker.com/r/eventstore/eventstore/)
|`Container`|Docker
|`UnitTest`|NUnit
|`integrationTest`|Xunit,[Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing)
|`CI CD`| GitHub Actions

                   
### How to Run
> **Note:** Enusre  your **Docker**  is Update To Date .


>*Run the following command to setup whole Applications and dependencies (Run in the folder where the Docker-compose file is located)*

    docker-compose up 




## Monitoring/Dashbords : 

|                |                       |
|------------------------|-------------------------------|
|`kafka` |   http://localhost:9000/              
|`EventStoreDb`| http://localhost:2113/                 
|`Api/Swagger`| http://localhost:4835/swagger/index.html
|`OrderServiceApp`|  http://localhost:10043 (*`not reachable at the browser`*)
|`CustomerServiceApp`| http://localhost:4835  (*`not reachable at the browser`*)     


## WorkFlow : 
![WorkFlow](https://user-images.githubusercontent.com/46053042/160236894-9480c608-29cc-428e-914a-156400415c95.jpg)

