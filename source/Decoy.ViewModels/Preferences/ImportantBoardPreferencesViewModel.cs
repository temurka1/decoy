namespace Decoy.ViewModels.Preferences
{
    using System.Collections.ObjectModel;

    using MvvmValidation;

    using Common;
    using Infrastructure;
    using Domain.Models;

    using Items;

    public class ImportantBoardPreferencesViewModel : ValidatableBindableBase
    {
        #region Fields

        private readonly DecoyDbContext _dbContext;
        private readonly ProjectSettings _projectSettings;

        private ObservableCollection<MaterialViewModel> _materials;
        private MaterialViewModel _selectedMaterial;

        private ObservableCollection<SurfaceFinishTypeViewModel> _surfaceFinishTypes;
        private SurfaceFinishTypeViewModel _selectedSurfaceFinish;

        private ObservableCollection<SolderMasksViewModel> _solderMaskColors;
        private SolderMasksViewModel _selectedSolderMaskColor;

        private decimal _boardThickness;

        #endregion

        #region Properties

        public decimal BoardThickness
        {
            get => _boardThickness;
            set
            {
                if (SetProperty(ref _boardThickness, value))
                {
                    _projectSettings.BoardThickness = _boardThickness;
                }
            }
        }

        public ObservableCollection<MaterialViewModel> Materials
        {
            get => _materials;
            set => SetProperty(ref _materials, value);
        }

        public MaterialViewModel SelectedMaterial
        {
            get => _selectedMaterial;
            set
            {
                if (SetProperty(ref _selectedMaterial, value) && _selectedMaterial != null)
                {
                    _projectSettings.Material = _selectedMaterial.Model;
                }
            }
        }

        public ObservableCollection<SurfaceFinishTypeViewModel> SurfaceFinishTypes
        {
            get => _surfaceFinishTypes;
            set => SetProperty(ref _surfaceFinishTypes, value);
        }

        public SurfaceFinishTypeViewModel SelectedSurfaceFinish
        {
            get => _selectedSurfaceFinish;
            set
            {
                if (SetProperty(ref _selectedSurfaceFinish, value) && _selectedSurfaceFinish != null)
                {
                    _projectSettings.SufraceFinish = _selectedSurfaceFinish.Model;
                }
            }
        }

        public ObservableCollection<SolderMasksViewModel> SolderMaskColors
        {
            get => _solderMaskColors;
            set => SetProperty(ref _solderMaskColors, value);
        }

        public SolderMasksViewModel SelectedSolderMaskColor
        {
            get => _selectedSolderMaskColor;
            set
            {
                if (SetProperty(ref _selectedSolderMaskColor, value) && _selectedSolderMaskColor != null)
                {
                    _projectSettings.SolderMask = _selectedSolderMaskColor.Model;
                }
            }
        }

        #endregion

        #region Constructors

        public ImportantBoardPreferencesViewModel(DecoyDbContext dbContext, ProjectSettings projectSettings)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); 
            _projectSettings = projectSettings ?? throw new ArgumentNullException(nameof(projectSettings));

            ConfigureValidationRules();
        }

        #endregion

        #region Methods

        public void LoadDefaults()
        {
            BoardThickness = 0;

            Materials = new ObservableCollection<MaterialViewModel>(_dbContext.Materials.Select(x => new MaterialViewModel(x)));
            SurfaceFinishTypes = new ObservableCollection<SurfaceFinishTypeViewModel>(_dbContext.SurfaceFinishTypes.Select(x => new SurfaceFinishTypeViewModel(x)));
            SolderMaskColors = new ObservableCollection<SolderMasksViewModel>(_dbContext.SolderMasks.Select(x => new SolderMasksViewModel(x)));

            SelectedMaterial = Materials.FirstOrDefault();
            SelectedSurfaceFinish = SurfaceFinishTypes.FirstOrDefault();
            SelectedSolderMaskColor = SolderMaskColors.FirstOrDefault();
        }

        private void ConfigureValidationRules()
        {
            Validator.AddRule(nameof(BoardThickness), () => RuleResult.Assert(BoardThickness > 0.0M, "Board Thickness is required"));
        }

        #endregion
    }
}
