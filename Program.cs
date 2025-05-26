using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Services;

var builder = WebApplication.CreateBuilder(args);

// Ajouter le contexte de base de données
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
    
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ExamService>();
builder.Services.AddScoped<ExamStudentService>();
builder.Services.AddScoped<LevelService>();
builder.Services.AddScoped<NationalityService>();
builder.Services.AddScoped<NoteSectionService>();
builder.Services.AddScoped<PeriodService>();
builder.Services.AddScoped<SectionService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<StudentLevelService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<VenueService>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<PrivilegeService>();
builder.Services.AddScoped<ProfLevelService>();
builder.Services.AddScoped<SectionScaleService>();
builder.Services.AddScoped<StaffService>();
builder.Services.AddScoped<CommentService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
