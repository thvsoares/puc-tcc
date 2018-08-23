using Microsoft.EntityFrameworkCore;

namespace PucTcc.Models
{
    public class PucTccContext : DbContext
    {
        public PucTccContext(DbContextOptions<PucTccContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoTurma>()
                .HasKey(t => new { t.IdAluno, t.IdTurma });

            modelBuilder.Entity<AlunoTurma>()
                .HasOne(pt => pt.Aluno)
                .WithMany(p => p.Turmas)
                .HasForeignKey(pt => pt.IdAluno);

            modelBuilder.Entity<AlunoTurma>()
                .HasOne(pt => pt.Turma)
                .WithMany(t => t.Alunos)
                .HasForeignKey(pt => pt.IdTurma);

            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Turma>().ToTable("Turma");
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    }
}