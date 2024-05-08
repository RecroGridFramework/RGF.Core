-------------------------------------------------
------------ RecroGrid Framework ------------
-------------------------------------------------

https://RecroGridFramework.com/

Quickstart:
-------------------------------------------------------------------------
1. After setting up the RecroGrid nupkg reference, you need to build the program,
which will result in the package generating the BaseDbContext in the Area\RGF\DbModel directory.

-------------------------------------------------------------------------
2. Update program.cs

builder.Services.AddCors(options =>
{
    options.AddPolicy("RGF.Client", b =>
    {
        var allowedOrigins = builder.Configuration
            .GetSection("CorsSettings:AllowedOrigins")
            .Get<string[]>();
        if (allowedOrigins != null)
        {
            b.WithOrigins(allowedOrigins)
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        }
    });
});

//Register RecroGrid Framework Services
builder.Services.AddControllersWithViews();
builder.AddRGF();
builder.AddBaseDbContext();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("RGF.Client");
app.UseAuthorization();

// Adds middleware for RecroGrid Framework Services.
app.UseRGF<BaseDbContext, BaseDbContextPool, BaseDbContextPool>();

app.MapControllers();
app.Run();

-------------------------------------------------------------------------
3. If ConnectionString does not exist yet, then add ConnectionString to appsettings.json 

  "ConnectionStrings": {
    "SQLServer": "Server=(localdb)\\mssqllocaldb;Database=DATABASE_NAME;Trusted_Connection=True;MultipleActiveResultSets=false;TrustServerCertificate=True;",
    //"SQLServer": "Server=.\\SQLExpress;Database=DATABASE_NAME;Trusted_Connection=True;MultipleActiveResultSets=false;TrustServerCertificate=True;",
    //"SQLServer": "Server=SQLServer2019.lan,1433;Database=DATABASE_NAME;User ID=USER_NAME;Password=PASSWORD;MultipleActiveResultSets=false;TrustServerCertificate=True;",
    "PostgreSQL": "Host=192.168.5.115;Database=DATABASE_NAME;Username=USER_NAME;Password=PASSWORD;Command Timeout=15",
    "Oracle21": "Data Source=Oracle21c:1521/xe;User Id=C##USER_NAME;Password=PASSWORD"
  }
  "CorsSettings": {
    "AllowedOrigins": [
      "https://{CLIENT-DOMAIN}" //e.g. "https://localhost:7099", "http://example.com"
    ]
  }

-------------------------------------------------------------------------
4. RGF Database Initialization

Start application and navigate /RGF/Admin
Click to "Database Initialization"

If you see Navigate to Entities, initialization is successful.

It is recommended to derive the BaseDbContex from your own DbContext.