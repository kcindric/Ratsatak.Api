#### Scaffold particular table(s)

```
dotnet ef dbcontext scaffold -p Ratsatak.Infrastructure -s Ratsatak.Api "host=localhost;database=ratsatak;username=ratsatak_sa;password={password};CommandTimeout=600;" Npgsql.EntityFrameworkCore.PostgreSQL -o Test -t geojson_cestice -f 
```