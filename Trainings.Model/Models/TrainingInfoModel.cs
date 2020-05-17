namespace Trainings.Model.Models
{
    using System;

    public class TrainingInfoModel
    {
        public int Id { get; set; }

        public byte TrainingTypeId { get; set; }

        public byte Duration { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
