namespace Trainings.Controller.Assemblers
{
    using System.Globalization;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

    internal static class TrainingAssembler
    {
        internal static TrainingInfoViewModel ToTrainingInfoViewModel(this TrainingInfoModel trainingInfoModel)
        {
            return new TrainingInfoViewModel
            {
                CreationDate = trainingInfoModel.CreationDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                Duration = trainingInfoModel.Duration.ToString(),
                TrainingTypeId = trainingInfoModel.TrainingTypeId.ToString()
            };
        }
    }
}
