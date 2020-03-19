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
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Lov> Lov { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformation { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingFrequency> TrainingFrequency { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPreference> UserPreference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercice>(entity =>
            {
                entity.Property(e => e.MuscleGroup).IsUnicode(false);

                entity.HasOne(d => d.ExerciceNavigation)
                    .WithMany(p => p.Exercice)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercice__Exerci__4AB81AF0");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Exercice)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercice__Traini__4BAC3F29");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Action).IsUnicode(false);

                entity.Property(e => e.Level).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Lov>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LovTypeName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.Property(e => e.ProfileLevel).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonalInformation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalI__UserI__45F365D3");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasOne(d => d.UserPreference)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.UserPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__UserPr__49C3F6B7");
            });

            modelBuilder.Entity<TrainingFrequency>(entity =>
            {
                entity.HasOne(d => d.UserPreference)
                    .WithMany(p => p.TrainingFrequency)
                    .HasForeignKey(d => d.UserPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TrainingF__UserP__47DBAE45");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__A9D1053481F3493C")
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
                    .HasConstraintName("FK__UserPrefe__Train__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreference)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__UserI__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
