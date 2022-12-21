namespace Decoy.ViewModels.Preferences
{
    using System.Text.RegularExpressions;

    using MvvmValidation;

    using Common;
    using Domain.Models;

    public class ProjectBasicsViewModel : ValidatableBindableBase
    {
        #region Fields

        private readonly ProjectSettings _projectSettings;

        private string _projectName;
        private string _zipcode;

        private int _boardsQuantity;

        #endregion

        #region Properties

        public string ProjectName
        {
            get => _projectName;
            set
            {
                if (SetProperty(ref _projectName, value))
                {
                    _projectSettings.Name = _projectName;
                }
            }
        }

        public string Zipcode
        {
            get => _zipcode;
            set
            {
                if (SetProperty(ref _zipcode, value))
                {
                    _projectSettings.Zipcode = _zipcode;
                }
            }
        }

        public int BoardsQuantity
        {
            get => _boardsQuantity;
            set
            {
                if (SetProperty(ref _boardsQuantity, value))
                {
                    _projectSettings.BoardsQuantity = _boardsQuantity;
                }
            }
        }

        #endregion

        #region Constructor

        public ProjectBasicsViewModel(ProjectSettings projectSettings)
        {
            _projectSettings = projectSettings ?? throw new ArgumentNullException(nameof(projectSettings));

            ConfigureValidationRules();

            ProjectName = string.Empty;
            Zipcode = string.Empty;
            BoardsQuantity = 0;
        }

        #endregion

        #region Methods

        private void ConfigureValidationRules()
        {
            Validator.AddRequiredRule(() => ProjectName, "Project Name is required");
            Validator.AddRequiredRule(() => Zipcode, "Zipcode is required");

            Validator.AddRule(nameof(BoardsQuantity), () => RuleResult.Assert(BoardsQuantity > 0, "Board Quantity is required"));
            Validator.AddRule(nameof(Zipcode), () => RuleResult.Assert(IsValidZipcode(Zipcode), "Zipcode is invalid"));
        }

        private bool IsValidZipcode(string zipcode)
        {
            return Regex.IsMatch(zipcode, @"^[0-9]{5}(?:-[0-9]{4})?$");
        }

        #endregion
    }
}
