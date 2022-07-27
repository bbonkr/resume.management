## Database migration

### Add migration

```shell
$ cd src/Resume.Data
$ dotnet ef migrations add "<message>" --startup-project ../Resume.App --project ../Resume.Data.SqlServer --context AppDbContext
```