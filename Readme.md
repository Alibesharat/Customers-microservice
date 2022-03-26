

###Implements Microservice and Event Sourcing of Customer Service App

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

                   



Enusre docker is uptodate

Run docker-compose up 

Monitoring/Dashbord : 

kafka :    http://localhost:9000/

EventStoreDb: http://localhost:2113/

---App Services ---
CustomerServiceApp Host url : http://localhost:10042
OrderServiceApp Host url : http://localhost:10043
Api/Swagger : http://localhost:4835/


 Docker build -f ./Services/CustomerServiceApp/Dockerfile  -t customer:latest .
 Docker build -f ./Services/OrderServiceApp/Dockerfile  -t order:latest .
 Docker build -f ./Services/AggregateGateway/Dockerfile  -t api:latest .


