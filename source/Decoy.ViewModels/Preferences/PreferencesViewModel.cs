namespace Decoy.ViewModels.Preferences
{
    using Prism.Mvvm;

    using Domain.Models;
    using Infrastructure;

    public class PreferencesViewModel : BindableBase
    {
        #region Properties

        public ProjectBasicsViewModel ProjectBasics { get; }

        public ImportantBoardPreferencesViewModel BoardPreferences { get; }

        public SpecialBoardPreferencesViewModel SpecialPreferences { get; }

        #endregion

        #region Constructors

        public PreferencesViewModel(ProjectSettings projectSettings, DecoyDbContext dbContext)
        {
            ProjectBasics = new ProjectBasicsViewModel(projectSettings);
            BoardPreferences = new ImportantBoardPreferencesViewModel(dbContext, projectSettings);
            SpecialPreferences = new SpecialBoardPreferencesViewModel(dbContext, projectSettings);

            LoadDefaults();
        }

        #endregion

        #region Methods

        public void LoadDefaults()
        {
            BoardPreferences.LoadDefaults();
            SpecialPreferences.LoadDefaults();
        }

        #endregion
    }
}
