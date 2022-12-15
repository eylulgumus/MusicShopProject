# MusicShop
# Description
MusicShop is an application that has been given to me as a school assignment. In this application, I have designed a website that can be used by music store owners.  
* In this application, the user can enter and store information about instruments, customers, manufacturers and orders in a database, and can also print these entities from the database on the views that i write.
*In my project, I used the .net core 6.0.11 n-layer MVC architecture,use mssql on database side and visual studio 2022 as a IDE.  
*I didnt be able to use api controller but if you need api controller i wrote them and they stored in controllers waiting in comment line
# How to Use The Project
1) I used db first approach you need to have query code in order to create the database
[QueryCode.txt](https://github.com/eylulgumus/MusicShopProject/files/10240044/QueryCode.txt)
2) You need some nuget packages:    *EntityFramework(6.4.4)  
*JqueryDataTables.ServerSide.AspNetCoreWeb(4.0.0) 
*Microsoft.AspNet.Mvc(5.2.9)    *Microsoft.AspNetCore.Identity.EntityFrameworkCore(6.0.11)  *Microsoft.AspNetCore.Mvc.ViewFeatures(2.2.0)  *Microsoft.AspNetCore.ResponseCompression(2.2.0)  *Microsoft.EntityFrameworkCore(6.0.11)  *Microsoft.EntityFrameworkCore.SqlServer(6.0.11)  
3)   ![image](https://user-images.githubusercontent.com/90522490/207773017-9fbc7ac4-1c58-4cdd-9e2d-ba1620b0d1f9.png)  
 Then as you can see in the image above you need to make some changes in appsettings.json in the MusicShop project."DefaultConnection":"Server=(YourServerName);Database="YourDataBaseName";Trusted_Connection=True".It'll connect your created database with the project.
4) You can start using the project.
(query you need to write in database)
