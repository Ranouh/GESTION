using Microsoft.EntityFrameworkCore;
using GESTION.model;

namespace GESTION.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Charger la chaîne de connexion depuis la configuration
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString); // Utilisation de PostgreSQL
            optionsBuilder.UseLazyLoadingProxies(); // Activer le chargement paresseux
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);

        //     // Configuration for Comment
        //     modelBuilder.Entity<Comment>()
        //         .HasMany(c => c.NoteSections)
        //         .WithOne(n => n.Comment)
        //         .HasForeignKey(n => n.CommentId);

        //     // Configuration for Exam
        //     modelBuilder.Entity<Exam>()
        //         .HasOne(e => e.Period)
        //         .WithMany(p => p.Exams)
        //         .HasForeignKey(e => e.PeriodId);

        //     modelBuilder.Entity<Exam>()
        //         .HasOne(e => e.Session)
        //         .WithMany(s => s.Exams)
        //         .HasForeignKey(e => e.SessionId);

        //     modelBuilder.Entity<Exam>()
        //         .HasOne(e => e.Level)
        //         .WithMany(l => l.Exams)
        //         .HasForeignKey(e => e.LevelId);

        //     // Configuration for ExamStudent
        //     modelBuilder.Entity<ExamStudent>()
        //         .HasOne(es => es.Exam)
        //         .WithMany(e => e.ExamStudents)
        //         .HasForeignKey(es => es.IdExam);

        //     modelBuilder.Entity<ExamStudent>()
        //         .HasOne(es => es.Student)
        //         .WithMany(s => s.ExamStudents)
        //         .HasForeignKey(es => es.IdStudent);

        //     // Other Entities
        //     modelBuilder.Entity<Level>()
        //         .HasMany(l => l.StudentLevels)
        //         .WithOne(sl => sl.Level)
        //         .HasForeignKey(sl => sl.LevelId);

        //     modelBuilder.Entity<Nationality>()
        //         .HasMany(n => n.Students)
        //         .WithOne(s => s.Nationality)
        //         .HasForeignKey(s => s.NationalityId);

        //     modelBuilder.Entity<Section>()
        //         .HasMany(s => s.NoteSections)
        //         .WithOne(ns => ns.Section)
        //         .HasForeignKey(ns => ns.SectionId);

        //     modelBuilder.Entity<SectionScale>()
        //         .HasOne(ss => ss.Section)
        //         .WithMany(s => s.SectionScales)
        //         .HasForeignKey(ss => ss.SectionId);

        //     modelBuilder.Entity<SectionScale>()
        //         .HasOne(ss => ss.Level)
        //         .WithMany(l => l.SectionScales)
        //         .HasForeignKey(ss => ss.LevelId);

        //     modelBuilder.Entity<SectionScale>()
        //         .HasOne(ss => ss.Subject)
        //         .WithMany(s => s.SectionScales)
        //         .HasForeignKey(ss => ss.SubjectId);

        //     modelBuilder.Entity<StudentLevel>()
        //         .HasOne(sl => sl.Student)
        //         .WithMany(s => s.StudentLevels)
        //         .HasForeignKey(sl => sl.StudentId);

        //     modelBuilder.Entity<StudentLevel>()
        //         .HasOne(sl => sl.Period)
        //         .WithMany(p => p.StudentLevels)
        //         .HasForeignKey(sl => sl.PeriodId);
    }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStudent> ExamStudents { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<NoteSection> NoteSections { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<ProfLevel> ProfLevels { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionScale> SectionScales { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLevel> StudentLevels { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Venue> Venues { get; set; }
}
