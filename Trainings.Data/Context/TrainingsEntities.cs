using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Trainings.Data.Tables;

namespace Trainings.Data.Context
{
    public partial class TrainingsEntities : DbContext
    {
        public TrainingsEntities()
        {
        }

        public TrainingsEntities(DbContextOptions<TrainingsEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Exercice> Exercice { get; set; }
        public virtual DbSet<ExerciceMuscleGroup> ExerciceMuscleGroup { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Lov> Lov { get; set; }
        public virtual DbSet<LovCategory> LovCategory { get; set; }
        public virtual DbSet<MuscleGroup> MuscleGroup { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformation { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingFrequency> TrainingFrequency { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPreference> UserPreference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercice>(entity =>
            {
                entity.HasOne(d => d.ExerciceNavigation)
                    .WithMany(p => p.ExerciceExerciceNavigation)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercice__Exerci__5070F446");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Exercice)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercice__Traini__52593CB8");

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.ExerciceTrainingType)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercice__Traini__5535A963");
            });

            modelBuilder.Entity<ExerciceMuscleGroup>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.MuscleGroup })
                    .HasName("PK__Exercice__E127108706CF7271");

                entity.Property(e => e.ExerciceId).ValueGeneratedOnAdd();

                entity.Property(e => e.MuscleGroup).IsUnicode(false);

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceM__Exerc__534D60F1");

                entity.HasOne(d => d.MuscleGroupNavigation)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.MuscleGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceM__Muscl__5441852A");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Action).IsUnicode(false);

                entity.Property(e => e.Level).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Lov>(entity =>
            {
                entity.Property(e => e.LovCategory).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.LovCategoryNavigation)
                    .WithMany(p => p.Lov)
                    .HasForeignKey(d => d.LovCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lov__LovCategory__5165187F");
            });

            modelBuilder.Entity<LovCategory>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__LovCateg__A25C5AA61DADDB2A");

                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<MuscleGroup>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__MuscleGr__A25C5AA64364CCC2");

                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.Property(e => e.ProfileLevel).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonalInformation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalI__UserI__4BAC3F29");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasOne(d => d.UserPreference)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.UserPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__UserPr__4F7CD00D");
            });

            modelBuilder.Entity<TrainingFrequency>(entity =>
            {
                entity.HasOne(d => d.UserPreference)
                    .WithMany(p => p.TrainingFrequency)
                    .HasForeignKey(d => d.UserPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingF__UserP__4D94879B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__A9D10534A8C80CE6")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.HashedPassword).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.RoleName).IsUnicode(false);
            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.UserPreference)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Train__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreference)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__UserI__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
