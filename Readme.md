# Implements Microservice and Event Sourcing in Asp.net 5

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
