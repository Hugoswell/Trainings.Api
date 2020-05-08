using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<UserLevel> UserLevel { get; set; }
        public virtual DbSet<UserPhysicalInformation> UserPhysicalInformation { get; set; }
        public virtual DbSet<UserPreferences> UserPreferences { get; set; }
        public virtual DbSet<UserSex> UserSex { get; set; }
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
                    .HasConstraintName("FK__Exercice__Equipm__6383C8BA");
            });

            modelBuilder.Entity<ExerciceGoal>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.GoalId })
                    .HasName("PK__Exercice__D56F617DA413EA70");

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceGoal)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceG__Exerc__66603565");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.ExerciceGoal)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceG__GoalI__6754599E");
            });

            modelBuilder.Entity<ExerciceMuscleGroup>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.MuscleGroupId })
                    .HasName("PK__Exercice__AD5C300645F760CC");

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceM__Exerc__68487DD7");

                entity.HasOne(d => d.MuscleGroup)
                    .WithMany(p => p.ExerciceMuscleGroup)
                    .HasForeignKey(d => d.MuscleGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceM__Muscl__693CA210");
            });

            modelBuilder.Entity<ExerciceTraining>(entity =>
            {
                entity.HasIndex(e => e.ExerciceId)
                    .HasName("FK__ExerciceTraining__ExerciceId");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("FK__ExerciceTraining__TrainingId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceTraining)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Exerc__619B8048");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.ExerciceTraining)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Train__628FA481");
            });

            modelBuilder.Entity<ExerciceTrainingType>(entity =>
            {
                entity.HasKey(e => new { e.ExerciceId, e.TrainingTypeId })
                    .HasName("PK__Exercice__47FAB17E277CAC5C");

                entity.HasOne(d => d.Exercice)
                    .WithMany(p => p.ExerciceTrainingType)
                    .HasForeignKey(d => d.ExerciceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Exerc__6477ECF3");

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.ExerciceTrainingType)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExerciceT__Train__656C112C");
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
                entity.HasIndex(e => e.TrainingTypeId)
                    .HasName("FK__Training__TrainingTypeId");

                entity.HasIndex(e => e.UserPreferencesId)
                    .HasName("FK__Training__UserPreferencesId");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__Traini__60A75C0F");

                entity.HasOne(d => d.UserPreferences)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.UserPreferencesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__UserPr__5FB337D6");
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
                    .HasName("UQ__User__A9D10534C965FD73")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.HashedPassword).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.RoleCode).IsUnicode(false);
            });

            modelBuilder.Entity<UserLevel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<UserPhysicalInformation>(entity =>
            {
                entity.HasIndex(e => e.LevelId)
                    .HasName("FK__UserPhysicalInformation__LevelId");

                entity.HasIndex(e => e.SexId)
                    .HasName("FK__UserPhysicalInformation__SexId");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK__UserPhysicalInformation__UserId");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.UserPhysicalInformation)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPhysi__Level__5DCAEF64");

                entity.HasOne(d => d.Sex)
                    .WithMany(p => p.UserPhysicalInformation)
                    .HasForeignKey(d => d.SexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPhysi__SexId__5EBF139D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPhysicalInformation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPhysi__UserI__571DF1D5");
            });

            modelBuilder.Entity<UserPreferences>(entity =>
            {
                entity.HasIndex(e => e.EquipmentId)
                    .HasName("FK__UserPreferences__EquipmentId");

                entity.HasIndex(e => e.GoalId)
                    .HasName("FK__UserPreferences__GoalId");

                entity.HasIndex(e => e.TrainingDurationId)
                    .HasName("FK__UserPreferences__TrainingDurationId");

                entity.HasIndex(e => e.TrainingTypeId)
                    .HasName("FK__UserPreferences__TrainingTypeId");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK__UserPreferences__UserId");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Equip__5CD6CB2B");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__GoalI__59FA5E80");

                entity.HasOne(d => d.TrainingDuration)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.TrainingDurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Train__5BE2A6F2");

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__Train__5AEE82B9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPrefe__UserI__5812160E");
            });

            modelBuilder.Entity<UserSex>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<UserTrainingFrequency>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("FK__UserTrainingFrequency__UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTrainingFrequency)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTrain__UserI__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
