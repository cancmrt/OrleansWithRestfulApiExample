# OrleansWithRestfulApiExample
Data and Domain Access Layer include ShopOrder CRUD operations with grains(single silo)
Hi this example use Microsoft Orleans .Net Core Build
I use Entity Framework so you can change Connection String from ShopContext.cs and you can easily migrate your database
(I use repository and unit of work patter for desing)
Solution has multiple project, I configure visual studio as multiple startup First have to run OrlensSilo project and then run RestApi project
RestApi have swagger ui for test(starting with it). I just add Get and Add method not implement others
In localhost:8080 we have orleans dashboard and you can see crated orleans and their performance
Application run just like in the below diagram, enjoy that!
![alt text](http://cmrt.in/wp-content/uploads/2019/07/Untitled-Diagram.jpg)

