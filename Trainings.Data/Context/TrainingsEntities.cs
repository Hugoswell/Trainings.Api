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
                entity.HasKey(e => e.Code)
                    .HasName("PK__Equipmen__A25C5AA6E11813C0");

                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<Exercice>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EquipmentCode).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.EquipmentCodeNavigation)
                    .WithMany(p => p.Exercice)
                    .HasForeignKey(d => d.EquipmentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercice__Equipm__5DCAEF64");
            });

            modelBuilder.Entity<ExerciceGoal>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.GoalCode })
                    .HasName("PK__Exercice__11D4869EAFF6CEC1");

                entity.Property(e => e.GoalCode).IsUnicode(false);

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceGoal)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceG__Exerc__60A75C0F");

                entity.HasOne(d => d.GoalCodeNavigation)
                    .WithMany(p => p.ExerciceGoal)
                    .HasForeignKey(d => d.GoalCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceG__GoalC__619B8048");
            });

            modelBuilder.Entity<ExerciceMuscleGroup>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.MuscleGroupCode })
                    .HasName("PK__Exercice__5F50AAD33EBAC218");

                entity.Property(e => e.MuscleGroupCode).IsUnicode(false);

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceM__Exerc__628FA481");

                entity.HasOne(d => d.MuscleGroupCodeNavigation)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.MuscleGroupCode)
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
                entity.HasKey(e => new { e.ExerciceId, e.TrainingTypeCode })
                    .HasName("PK__Exercice__487D55215A56DEA2");

                entity.Property(e => e.TrainingTypeCode).IsUnicode(false);

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceTrainingType)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Exerc__5EBF139D");

                entity.HasOne(d => d.TrainingTypeCodeNavigation)
                    .WithMany(p => p.ExerciceTrainingType)
                    .HasForeignKey(d => d.TrainingTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Train__5FB337D6");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Goal__A25C5AA6128C0274");

                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<MuscleGroup>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__MuscleGr__A25C5AA65A64CA43");

                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.TrainingTypeCode).IsUnicode(false);

                entity.HasOne(d => d.TrainingTypeCodeNavigation)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.TrainingTypeCode)
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
                entity.HasKey(e => e.Code)
                    .HasName("PK__Training__A25C5AA69AE6F27D");

                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<TrainingType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Training__A25C5AA6773B3F02");

                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__A9D105341CBFA9D7")
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
                entity.Property(e => e.EquipmentCode).IsUnicode(false);

                entity.Property(e => e.GoalCode).IsUnicode(false);

                entity.Property(e => e.TrainingDurationCode).IsUnicode(false);

                entity.Property(e => e.TrainingTypeCode).IsUnicode(false);

                entity.HasOne(d => d.EquipmentCodeNavigation)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.EquipmentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Equip__59063A47");

                entity.HasOne(d => d.GoalCodeNavigation)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.GoalCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__GoalC__5629CD9C");

                entity.HasOne(d => d.TrainingDurationCodeNavigation)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.TrainingDurationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Train__5812160E");

                entity.HasOne(d => d.TrainingTypeCodeNavigation)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.TrainingTypeCode)
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
