using Newtonsoft.Json;

namespace Trainings.Controller.ViewModels
{
    public class UserInfoViewModel
    {
        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("equipmentId")]
        public string EquipmentId { get; set; }
        
        [JsonProperty("goalId")]
        public string GoalId { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("levelId")]
        public string LevelId { get; set; }

        [JsonProperty("sexId")]
        public string SexId { get; set; }

        [JsonProperty("trainingDurationId")]
        public string TrainingDurationId { get; set; }

        [JsonProperty("trainingTypeId")]
        public string TrainingTypeId { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }
    }
}
