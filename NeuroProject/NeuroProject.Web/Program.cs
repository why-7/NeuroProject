using Microsoft.EntityFrameworkCore;
using NeuroProject.BLL.Services;
using NeuroProject.DAL.Models;
using NeuroProject.DAL.Repositories.Implementations;
using NeuroProject.DAL.Repositories.Interfaces;
using NeuroProject.BLL.BusinessModels;
using NeuroProject.DAL;
using NeuroProject.Web.Dto;
using NeuroProject.Web.Dto.Response;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ResearchesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"),
        x => x.MigrationsAssembly("NeuroProject.DAL")));
            
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IResearchRepository, ResearchRepository>();
builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<ITestSubjectRepository, TestSubjectRepository>();
builder.Services.AddScoped<IResearchesService, ResearchesService>();
builder.Services.AddAutoMapper(cfg => 
{
    cfg.CreateMap<CreateResearchDto, ResearchBm>();
    cfg.CreateMap<AddTestSubjectDto, TestSubjectBm>();
    cfg.CreateMap<AddRecordDto, RecordBm>();
    cfg.CreateMap<ResearchBm, Research>();
    cfg.CreateMap<TestSubjectBm, TestSubject>();
    cfg.CreateMap<RecordBm, Record>();
    cfg.CreateMap<Research, ResearchBm>();
    cfg.CreateMap<TestSubject, TestSubjectBm>();
    cfg.CreateMap<Record, RecordBm>();
    cfg.CreateMap<ResearchBm, ResearchDto>();
    cfg.CreateMap<TestSubjectBm, TestSubjectDto>();
    cfg.CreateMap<RecordBm, RecordDto>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
