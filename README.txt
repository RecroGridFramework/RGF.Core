-------------------------------------------------
------------ RecroGrid Framework 6.x ------------
-------------------------------------------------

Documentation: https://RecroGrid.com/docs

Quickstart:
-------------------------------------------------------------------------
1. After setting up the RecroGrid nupkg reference, you need to build the program,
which will result in the package generating the BaseDbContext in the Area\RGF\DbModel directory.

-------------------------------------------------------------------------
2. Update program.cs

//Register RecroGrid Framework Services
builder.Services.AddControllersWithViews();
builder.AddRGF();
builder.AddBaseDbContext();

var app = builder.Build();

// Adds middleware for RecroGrid Framework Services.
app.UseStaticFiles();
app.UseRouting();
app.UseRGF<BaseDbContext, BaseDbContextPool, BaseDbContextPool>();

app.MapControllers();
app.Run();

-------------------------------------------------------------------------
3. If ConnectionString does not exist yet, then add ConnectionString to appsettings.json 

  "ConnectionStrings": {
    "SQLServer": "Server=(localdb)\\mssqllocaldb;Database=DATABASE_NAME;Trusted_Connection=True;MultipleActiveResultSets=false",
    //"SQLServer": "Server=.\\SQLExpress;Database=DATABASE_NAME;Trusted_Connection=True;MultipleActiveResultSets=false",
    //"SQLServer": "Server=SQLServer2019.lan,1433;Database=DATABASE_NAME;User ID=USER_NAME;Password=PASSWORD;MultipleActiveResultSets=false",
    "PostgreSQL": "Host=192.168.5.115;Database=DATABASE_NAME;Username=USER_NAME;Password=PASSWORD;Command Timeout=15",
    "Oracle21": "Data Source=Oracle21c:1521/xe;User Id=C##USER_NAME;Password=PASSWORD"
  }

-------------------------------------------------------------------------
4. RGF Database Initialization

Start application and navigate /RGF/Admin
Click to "Database Initialization"

If you see Navigate to Entities, initialization is successful.
