# Implements Microservice and Event Sourcing in .net 5


 ## Autamation Build :

![Dotnet](https://github.com/Alibesharat/Customers-microservice/actions/workflows/dotnet.yml/badge.svg)

[![Docker Image CI Cutomer](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.customer.yml/badge.svg)](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.customer.yml)

[![Docker Image CI Api](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.api.yml/badge.svg)](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.api.yml)

[![Docker Image CI Order](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.order.yml/badge.svg)](https://github.com/Alibesharat/Customers-microservice/actions/workflows/docker-image.order.yml)


 ## Technologies


|                |                       |
|------------------------|-------------------------------|
|`Langauge` |C#                 
|`Framework`|.Net5                 
|`validation`|[FluentValidation](https://github.com/FluentValidation/FluentValidation)
|`Mapping`|[Mapster](https://github.com/MapsterMapper/Mapster)
|`Sync Communication`|[Model First Grpc ](https://github.com/protobuf-net/protobuf-net.Grpc)                    
|`ASync Communication (MessageBroker)`| Kafka
|`Storage`|[EvnetStoreDb](https://hub.docker.com/r/eventstore/eventstore/)
|`Container`|Docker
|`UnitTest`|NUnit
|`integrationTest`|Xunit,[Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing)
|`CI CD`| GitHub Actions

                   
### How to Run
> **Note:** Enusre  your **Docker**  is Update To Date .


> *We have to build  **local images** on **docker**  , go to **root folder** and run the Following Commands* : 



    docker build -f ./Services/CustomerServiceApp/Dockerfile  -t customer:latest .
    docker build -f ./Services/OrderServiceApp/Dockerfile  -t order:latest .
    docker build -f ./Services/AggregateGateway/Dockerfile  -t api:latest .

>*Run the following command to setup whole Applications and dependencies*

    docker-compose up 




## Monitoring/Dashbords : 

|                |                       |
|------------------------|-------------------------------|
|`kafka` |   http://localhost:9000/              
|`EventStoreDb`| http://localhost:2113/                 
|`Api/Swagger`| http://localhost:4835/
|`OrderServiceApp`|  http://localhost:10043 (*`not reachable at the browser`*)
|`CustomerServiceApp`| http://localhost:4835  (*`not reachable at the browser`*)             
