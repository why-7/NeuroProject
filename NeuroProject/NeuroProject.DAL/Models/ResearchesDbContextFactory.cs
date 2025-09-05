using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NeuroProject.DAL.Models;

public class ResearchesDbContextFactory : IDesignTimeDbContextFactory<ResearchesDbContext>
{
    public ResearchesDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ResearchesDbContext>();

        // ❗ Важно: укажи точную строку подключения (вручную), EF не подтянет из Program.cs
        var connectionString = "Host=localhost;Port=5432;Username=postgres;Database=postgres";

        optionsBuilder.UseNpgsql(connectionString,
            x => x.MigrationsAssembly("NeuroProject.DAL"));

        return new ResearchesDbContext(optionsBuilder.Options);
    }
}
