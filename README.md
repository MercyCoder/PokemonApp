# PokemonApp
Collaboratively Built Pokemon Mvc App
 This README is written, at least temporarily, for fellow Academy Pgh students and may contain references to our specific learning environment.
The above is a link to the middle group's Pokemon App.
Some things that we ran into are:
1. When we made our models we made ints called T_id and P_id expecting that we would have those be the joining id columns between catches and pokemon/trainers. However we also made columns that were instantiated as classes and we called these Trainer and Pokemon, identical to their corresponding classes. But then Mvc was all like: “Oh you want those to be the linking id columns, yeah?” So when we looked at our Catch table we saw Trainerid and Pokemonid. But those (as opposed to out int columns) were allowed to be null, and were not automatically populated as enterable fields in our views… 
 
So we deleted our migration (by going to the finder and deleting there) and we did have to closed and open Visual Studio to make those files disappear in our solution. Then we went through and changed our scaffolding one “T_id” and “P_id” at a time. We actually did this more than once we would run the program and it would show us file after file that needed to be changed before it would run. 
 
Then we ran into an instance of the program ran in the browser but it wouldn’t migrate, giving us the super helpful error “build failed” 
 
We lost our minds for a minute until we realized the build was failing simply because it was still running in the browser. Dumb.
 
We learned a thing or two about how there are two CRUD actions with classically similar names. “IActionResult Create()” (equatable to the new action in Rails) and
“Task<IActionResult> Create”  (equatable to the create action in Rails)  
 
Also dumb. 
 
A couple things to remember if you clone this project: 
1. On line 31 (ish --depending) of the Startup.cs you’ll want to change the path to the database so that it reflects a path to where you want to store your database on your local machine. 
```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //instantiating a class (or blueprint) of the batabase context
            services.AddDbContext<PokeContext>(options => options.UseSqlite("Data Source=/Users/mercy/dbs/Pokedex.db"));
        }
```
Here you can also change the structure to reflect John’s Friday demonstration with the connection string declared as a variable outside of the function. 
 
Also don’t forget to add all the required NuGet packages to this project (now until forever dumb) 
```
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
 
Finally one more issue that I don’t expect anyone to run into but was interesting to resolve was that when Jesse tried to run the project as he had been running projects since we started working with Mvc. An error saying that that port was currently in use came back. We looked into some solutions to this and StackOverflow gave us some alternate ports to try. 
 
Every port recommended to us was also in use. So weird. So we just guessed a port, and it was a good one.  This led me down a rabbit hole into portal use. If you would like to follow me: https://www.bleepingcomputer.com/tutorials/tcp-and-udp-ports-explained/
 
