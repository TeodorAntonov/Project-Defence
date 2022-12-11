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
This project contains following class folders:
- Constatns - Contants of the data ranges and user rols names 
- Entities - All data classes which are represented as database objects
- Models - All models which are used in the different views

#### Interfaces
This project contains all interfaces created for Services.

#### ProjectDefence
This project contains controllers, areas, Views, images, connections and program.cs of the project.

#### Repositories
This project contains DB Context and all migrations of the project. The app is Code-First approach and the database can be changed from here.

#### Services
This project contains all services of the project

#### Tests Folder
This folder contains all unit tests of services and controlllers. The Controllers unit tests are put in a sub-folder so to be separeted and distinguished from the services unit tests.

<h1>---------</h1>
<h1>Instructions about: How to run the app</h1>

**FIRST** - Go to **application.json** and add your server with database name ProjectDafence. Then go to Package Manager Console and on __*Default Project*__ select __*Repositories*__ and execute Update-Database command to create the base.
Please note that there are some seed data in the tables. The data entities are **ONLY** for presentaion purpose! They are put just in case if you need to check only how it looks the design of app. 

<img src="/ProjectDefence/wwwroot/adddingRoles.jpg" alt="adding roles" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/addRoles.jpg" alt="add roles" style="height: 200px; width:400px;"/>


**SECOND** - To work the App correctly and to use all the roles and administration field you need to add parameters to following URLs (EXECUTE THEM ONCE IN THE MAIN PAGE BEFORE USING OTHER FUNCTIONS): 
First execution (Example) your localhost:****/User/CreateRoles <- this is for setting the roles.

<img src="/ProjectDefence/wwwroot/adding Admin.jpg" alt="adding admin" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/addAdmin.jpg" alt="add admin" style="height: 200px; width:400px;"/>


Second execution (Example) your localhost:****/User/AddAdminUser <- this is for setting the admin.

The Admin is hardcoded so if you want to use the admin profile, write the following credentials: UserName: Administrator / Password: Admin1!

<h1>---------</h1>
<h1>Brief presentaion for all Roles</h1>

#### Administrator

The Admin Role has most of the rights in the app. He/she can add trainers and gyms to the sysmtem, also has his/her own admin mail box where the admin can see who has applied for trainer's position.
The Admin decides to whom can be permitted to be trainer. The Admin has own panel where can delete users or edit their statuses and infos.
Check the following pictures as example.
**This is the Home Page and the Admin Panel's options:**
<img src="/ProjectDefence/wwwroot/ImagesForReadme/AdminHome.jpg" alt="admin home" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/AdminPanel.jpg" alt="admin panel" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/AddGym.jpg" alt="add gym" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/AddTrainer.jpg" alt="add trainer" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/AllUsers.jpg" alt="all users" style="height: 200px; width:400px;"/>

**The admin can give permission (roles) to clients, of course, depending of their work or need.**
<img src="/ProjectDefence/wwwroot/ImagesForReadme/userProfile1.jpg" alt="user profile" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/userProfile2.jpg" alt="user profile part2" style="height: 200px; width:400px;"/>

<h5>--</h5>

**The Admin can edit and delete Trainers and Gyms**

<img src="/ProjectDefence/wwwroot/ImagesForReadme/AllGyms.jpg" alt="all gyms" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/EditGym.jpg" alt="edit gym" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/All Trainers.jpg" alt="all trainer" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/Edit Trainer.jpg" alt="edit trainer" style="height: 200px; width:400px;"/>

<h5>---------</h5>

#### Client

After registrating and loging of the new client, the user will have a options like, applying to become a trainer, applying for a particular trainer and his own Clinet Profile.

This is the Client's Home Page:
<img src="/ProjectDefence/wwwroot/ImagesForReadme/Client1.jpg" alt="client" style="height: 200px; width:400px;"/>

When you click on My Profile button next to Logout. You will be redirect to User's statistic, Workout Plan and Fitness Dairy.
First You need to set your current statuses. Once You set them a button Update My profile will appear and you will be able to manage your profile.

**Before Updating Profile**

<img src="/ProjectDefence/wwwroot/ImagesForReadme/emptyClientProfile.jpg" alt="client profile" style="height: 200px; width:400px;"/>

**After Updating Profile**

<img src="/ProjectDefence/wwwroot/ImagesForReadme/UpdatedProfileClient.jpg" alt="update profile" style="height: 200px; width:400px;"/>

A Client can apply to be become a trainer from the Button in Home Page. If the client is approved to become a trainer, the admin will set his role and the user will receive new rights and the apply button will become a notification that he is a trainer.
This is a screenshot of the application form of what the user need to present in his application:

<img src="/ProjectDefence/wwwroot/ImagesForReadme/ApplicationFrom.jpg" alt="application form" style="height: 200px; width:400px;"/>

<h5>---------</h5>

#### Trainer

After A client beacomes a Trainer. It will appears a few options - Requests Mails and Check Your Clients:

<img src="/ProjectDefence/wwwroot/ImagesForReadme/TrainerOptions.jpg" alt="trainer options" style="height: 200px; width:400px;"/>

Requests Mails are actually requests from client if the trainer wants to trainer them or not. The Trainer has 2 options - To Accept the client or to declined his/her request.

<img src="/ProjectDefence/wwwroot/ImagesForReadme/ClientsRequests.jpg" alt="trainer clients requests" style="height: 200px; width:400px;"/>

Check Your Clients (light blue button in the Home Page) shows all clients who are under this trainer's guiding. The trainer is able to see the stats of his clients and has the options to Create a new workout or delete the client and not work with him anymore.

<img src="/ProjectDefence/wwwroot/ImagesForReadme/YourClients.jpg" alt="your clients" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/createWorkout.jpg" alt="create workout" style="height: 200px; width:400px;"/>

<h5>---------</h5>

#### Writer

The Writer is the one who add new posts and managing the exercises. He/she can create exercises and writer new posts ( in a seperated area). The role can be given by the Admin, even though the writer is client, he/she is an administrative person who updates with posts inside the system. Not Always admins are writer and writers are not admins.
This is the business logic idea - the system responsibilites to be separated between one big and one small role.

<img src="/ProjectDefence/wwwroot/ImagesForReadme/Writer.jpg" alt="writer" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/New Post.jpg" alt="new post" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/PostCreated.jpg" alt="post created" style="height: 200px; width:400px;"/>

After creating new post, the post will appear first in all 4 posts. If you want to see all posts click the button on bottom of Home Page **All Posts**

<img src="/ProjectDefence/wwwroot/ImagesForReadme/NewAddedPost.jpg" alt="new add post" style="height: 200px; width:400px;"/>

<h1>---------</h1>
<h1>How to Register a Trainer</h1>

After a client sent its application to the administration, The admin will review it in the Admin Mail Box and he will decide if the client has enough reasons to become a trainer.
The Admin needs to get the User's info, ESCPECIALLY the user's' Id. He needs to copy it and then he needs to go Add Trainer in the Admin Panel. He puts the information and on the last field below, The admin needs to paste the user's Id. 

<img src="/ProjectDefence/wwwroot/ImagesForReadme/trainerInCreation.jpg" alt="new add post" style="height: 200px; width:400px;"/>
<img src="/ProjectDefence/wwwroot/ImagesForReadme/trainerInCreation2.jpg" alt="new add post" style="height: 200px; width:400px;"/>

After creating the trainer, the admin needs to update the roles and rights of the current client as he needs to go to Admin Panel section and select All Users - there he should select the user who is now a trainer. The admin has to scroll down
to the bottom of the page and to click/check trainer role then clicks Save. Now the user should have trainer rights.

<img src="/ProjectDefence/wwwroot/ImagesForReadme/Creation of trainer.jpg" alt="new add post" style="height: 200px; width:400px;"/>
