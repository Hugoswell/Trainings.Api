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

        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Exercice> Exercice { get; set; }
        public virtual DbSet<ExerciceGoal> ExerciceGoal { get; set; }
        public virtual DbSet<ExerciceMuscleGroup> ExerciceMuscleGroup { get; set; }
        public virtual DbSet<ExerciceTraining> ExerciceTraining { get; set; }
        public virtual DbSet<ExerciceTrainingType> ExerciceTrainingType { get; set; }
        public virtual DbSet<Goal> Goal { get; set; }
        public virtual DbSet<MuscleGroup> MuscleGroup { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingDuration> TrainingDuration { get; set; }
        public virtual DbSet<TrainingType> TrainingType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPhysicalInformation> UserPhysicalInformation { get; set; }
        public virtual DbSet<UserPreferences> UserPreferences { get; set; }
        public virtual DbSet<UserTrainingFrequency> UserTrainingFrequency { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Exercice>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Exercice)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercice__Equipm__5DCAEF64");
            });

            modelBuilder.Entity<ExerciceGoal>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.GoalId })
                    .HasName("PK__Exercice__D56F617D5DA80AB8");

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceGoal)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceG__Exerc__60A75C0F");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.ExerciceGoal)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceG__GoalI__619B8048");
            });

            modelBuilder.Entity<ExerciceMuscleGroup>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.MuscleGroupId })
                    .HasName("PK__Exercice__AD5C3006D1D8D553");

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceM__Exerc__628FA481");

                entity.HasOne(d => d.MuscleGroup)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.MuscleGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceM__Muscl__6383C8BA");
            });

            modelBuilder.Entity<ExerciceTraining>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceTraining)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Exerc__5BE2A6F2");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.ExerciceTraining)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Train__5CD6CB2B");
            });

            modelBuilder.Entity<ExerciceTrainingType>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.TrainingTypeId })
                    .HasName("PK__Exercice__47FAB17EFD28756D");

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceTrainingType)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Exerc__5EBF139D");

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.ExerciceTrainingType)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Train__5FB337D6");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<MuscleGroup>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__Traini__5AEE82B9");

                entity.HasOne(d => d.UserPreferences)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.UserPreferencesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__UserPr__59FA5E80");
            });

            modelBuilder.Entity<TrainingDuration>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<TrainingType>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__A9D10534B69B762E")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.HashedPassword).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.RoleCode).IsUnicode(false);
            });

            modelBuilder.Entity<UserPhysicalInformation>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPhysicalInformation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPhysi__UserI__534D60F1");
            });

            modelBuilder.Entity<UserPreferences>(entity =>
            {
                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Equip__59063A47");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__GoalI__5629CD9C");

                entity.HasOne(d => d.TrainingDuration)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.TrainingDurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Train__5812160E");

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Train__571DF1D5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__UserI__5441852A");
            });

            modelBuilder.Entity<UserTrainingFrequency>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTrainingFrequency)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTrain__UserI__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
