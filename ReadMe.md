# ProjectDefence - Fitness Administrative App

This application is a demo app for SoftUni Asp .Net/Web course 2022.

<h1>Resume:</h1>
Fintess App for any gym's administration. You have clients who want to have personal online trainers. They can apply for any registrated trainer in the system and if a trainer decide to train them, the clients will recieve a new fitness program with description who to perform the exerces.
Tha system is very basic level of quick actions and responses between clients, trainers, and administrators. It is allowed to any client to apply to become a trainer. Only the admins have the rights to make a client to trainer. There is a small notification (mail) box for any trainer and also for any admin.
There is a second administrative section for writers. They are the users who write upload new articles(posts) for any fun-side zone. They can also add exercises' descriptions in a section for exercises.

<h1>---------</h1>
<h1>Project Overview</h1>
<h6>Monolith Architecuture</h6>
<img src="/ProjectDefence/wwwroot/Monolith_Architecuture.png" alt="Monolith Architecuture" style="height: 600px; width:500px;"/>
<img src="/ProjectDefence/wwwroot/project-overview.jpg" alt="project-overview" style="height: 250px; width:400px;"/>

#### DataModels
This solution contains following class folders:
- Constatns - Contants of the data ranges and user rols names 
- Entities - All data classes which are represented as database objects
- Models - All models which are used in the different views

#### Interfaces
This solution contains all interfaces created for Services.

#### ProjectDefence
This solution contains controllers, areas, Views, images, connections and program.cs of the project.

#### Repositories
This solution contains DB Context and all migrations of the project. The app is Code-First approach and the database can be changed from here.

#### Services
This solution contains all services of the project