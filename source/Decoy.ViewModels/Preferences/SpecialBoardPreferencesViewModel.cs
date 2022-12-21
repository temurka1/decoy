namespace Decoy.ViewModels.Preferences
{
    using System.Collections.ObjectModel;

    using Prism.Mvvm;

    using Decoy.Domain.Enums;
    using Decoy.Infrastructure;
    using Decoy.ViewModels.Preferences.Items;
    using Decoy.Domain.Models;

    public class SpecialBoardPreferencesViewModel : BindableBase
    {
        #region Fields

        private readonly DecoyDbContext _dbContext;
        private readonly ProjectSettings _projectSettings;

        private ObservableCollection<LeadFree> _leadFreeValues;
        private LeadFree _selectedLeadFree;

        private ObservableCollection<IpcClass> _ipcClassValues;
        private IpcClass _selectedIpcClass;

        private ObservableCollection<Itar> _itarValues;
        private Itar _selectedItar;

        private ObservableCollection<FluxType> _fluxTypeValues;
        private FluxType _selectedFluxType;

        private ObservableCollection<ControlledImpendance> _controlledImpendanceValues;
        private ControlledImpendance _selectedControlledImpendance;

        private ObservableCollection<TentingForVias> _tentingForViasValues;
        private TentingForVias _selectedTentingForVias;

        private ObservableCollection<Stackup> _stackupValues;
        private Stackup _selectedStackup;

        private string _notes;

        private ObservableCollection<SilkscreenColorViewModel> _silkscreenColors;
        private SilkscreenColorViewModel _selectedSilkscreenColor;

        private ObservableCollection<CooperWeightViewModel> _innerLayerCooperWeights;
        private CooperWeightViewModel _selectedInnerLayerCooperWeight;

        private ObservableCollection<CooperWeightViewModel> _outerLayerCooperWeights;
        private CooperWeightViewModel _selectedOuterLayerCooperWeight;

        #endregion

        #region Properties

        public ObservableCollection<LeadFree> LeadFreeValues
        {
            get => _leadFreeValues;
            set => SetProperty(ref _leadFreeValues, value);
        }

        public LeadFree SelectedLeadFree
        {
            get => _selectedLeadFree;
            set
            {
                if (SetProperty(ref _selectedLeadFree, value))
                {
                    _projectSettings.LeadFree = _selectedLeadFree;
                }
            }
        }

        public ObservableCollection<IpcClass> IpcClassValues
        {
            get => _ipcClassValues;
            set => SetProperty(ref _ipcClassValues, value);
        }

        public IpcClass SelectedIpcClass
        {
            get => _selectedIpcClass;
            set
            {
                if (SetProperty(ref _selectedIpcClass, value))
                {
                    _projectSettings.IpcClass = _selectedIpcClass;
                }
            }
        }

        public ObservableCollection<Itar> ItarValues
        {
            get => _itarValues;
            set => SetProperty(ref _itarValues, value);
        }

        public Itar SelectedItar
        {
            get => _selectedItar;
            set
            {
                if (SetProperty(ref _selectedItar, value))
                {
                    _projectSettings.Itar = _selectedItar;
                }
            }
        }

        public ObservableCollection<FluxType> FluxTypeValues
        {
            get => _fluxTypeValues;
            set => SetProperty(ref _fluxTypeValues, value);
        }

        public FluxType SelectedFluxType
        {
            get => _selectedFluxType;
            set
            {
                if (SetProperty(ref _selectedFluxType, value))
                {
                    _projectSettings.FluxType = _selectedFluxType;
                }
            }
        }

        public ObservableCollection<ControlledImpendance> ControlledImpendanceValues
        {
            get => _controlledImpendanceValues;
            set => SetProperty(ref _controlledImpendanceValues, value);
        }

        public ControlledImpendance SelectedControlledImpendance
        {
            get => _selectedControlledImpendance;
            set
            {
                if (SetProperty(ref _selectedControlledImpendance, value))
                {
                    _projectSettings.ControlledImpendance = _selectedControlledImpendance;
                }
            }
        }

        public ObservableCollection<TentingForVias> TentingForViasValues
        {
            get => _tentingForViasValues;
            set => SetProperty(ref _tentingForViasValues, value);
        }

        public TentingForVias SelectedTentingForVias
        {
            get => _selectedTentingForVias;
            set
            {
                if (SetProperty(ref _selectedTentingForVias, value))
                {
                    _projectSettings.TentingForVias = _selectedTentingForVias;
                }
            }
        }

        public ObservableCollection<Stackup> StackupValues
        {
            get => _stackupValues;
            set => SetProperty(ref _stackupValues, value);
        }

        public Stackup SelectedStackup
        {
            get => _selectedStackup;
            set
            {
                if (SetProperty(ref _selectedStackup, value))
                {
                    _projectSettings.Stackup = _selectedStackup;
                }
            }
        }

        public string Notes
        {
            get => _notes;
            set
            {
                if (SetProperty(ref _notes, value))
                {
                    _projectSettings.Notes = _notes;
                }
            }
        }

        public ObservableCollection<SilkscreenColorViewModel> SilkscreenColors
        {
            get => _silkscreenColors;
            set => SetProperty(ref _silkscreenColors, value);
        }

        public SilkscreenColorViewModel SelectedSilkscreenColor
        {
            get => _selectedSilkscreenColor;
            set
            {
                if (SetProperty(ref _selectedSilkscreenColor, value) && _selectedSilkscreenColor != null)
                {
                    _projectSettings.SilkscreenColor = _selectedSilkscreenColor.Model;
                }
            }
        }

        public ObservableCollection<CooperWeightViewModel> InnerLayerCooperWeights
        {
            get => _innerLayerCooperWeights;
            set => SetProperty(ref _innerLayerCooperWeights, value);
        }

        public CooperWeightViewModel SelectedInnerLayerCooperWeight
        {
            get => _selectedInnerLayerCooperWeight;
            set 
            {
                if (SetProperty(ref _selectedInnerLayerCooperWeight, value) && _selectedInnerLayerCooperWeight != null)
                {
                    _projectSettings.InnerLayerCooperWeight = _selectedInnerLayerCooperWeight.Model;
                }
            }
        }

        public ObservableCollection<CooperWeightViewModel> OuterLayerCooperWeights
        {
            get => _outerLayerCooperWeights;
            set => SetProperty(ref _outerLayerCooperWeights, value);
        }

        public CooperWeightViewModel SelectedOuterLayerCooperWeight
        {
            get => _selectedOuterLayerCooperWeight;
            set
            {
                if (SetProperty(ref _selectedOuterLayerCooperWeight, value) && _selectedOuterLayerCooperWeight != null)
                {
                    _projectSettings.OuterLayerCooperWeight = _selectedOuterLayerCooperWeight.Model;
                }
            }
        }

        #endregion

        #region Constructors

        public SpecialBoardPreferencesViewModel(DecoyDbContext dbContext, ProjectSettings projectSettings)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _projectSettings = projectSettings ?? throw new ArgumentNullException(nameof(projectSettings));
        }

        #endregion

        #region Methods

        public void LoadDefaults()
        {
            LeadFreeValues = new ObservableCollection<LeadFree>
            {
                LeadFree.Yes,
                LeadFree.No
            };

            IpcClassValues = new ObservableCollection<IpcClass>
            {
                IpcClass.Class2,
                IpcClass.Class3
            };

            ItarValues = new ObservableCollection<Itar>
            {
                Itar.Yes,
                Itar.No
            };

            FluxTypeValues = new ObservableCollection<FluxType>
            {
                FluxType.Clean,
                FluxType.NoClean
            };

            ControlledImpendanceValues = new ObservableCollection<ControlledImpendance>
            {
                ControlledImpendance.None,
                ControlledImpendance.SeeNotes
            };

            TentingForViasValues = new ObservableCollection<TentingForVias>
            {
                TentingForVias.BothSides,
                TentingForVias.TopSide,
                TentingForVias.BottomSide,
                TentingForVias.None
            };

            StackupValues = new ObservableCollection<Stackup>
            {
                Stackup.Standard,
                Stackup.SeeNotes
            };

            InnerLayerCooperWeights = new ObservableCollection<CooperWeightViewModel>(_dbContext.CooperWeights.Where(x => x.IsInner).Select(x => new CooperWeightViewModel(x)));
            OuterLayerCooperWeights = new ObservableCollection<CooperWeightViewModel>(_dbContext.CooperWeights.Where(x => !x.IsInner).Select(x => new CooperWeightViewModel(x)));

            SilkscreenColors = new ObservableCollection<SilkscreenColorViewModel>(_dbContext.SilkscreenColors.Select(x => new SilkscreenColorViewModel(x)));

            SelectedSilkscreenColor = SilkscreenColors.FirstOrDefault();
            SelectedInnerLayerCooperWeight = InnerLayerCooperWeights.FirstOrDefault();
            SelectedOuterLayerCooperWeight = OuterLayerCooperWeights.FirstOrDefault();
            
            SelectedLeadFree = LeadFreeValues.FirstOrDefault(x => x == LeadFree.Yes);
            SelectedIpcClass = IpcClassValues.FirstOrDefault(x => x == IpcClass.Class2);
            SelectedItar = ItarValues.FirstOrDefault(x => x == Itar.No);
            SelectedFluxType = FluxTypeValues.FirstOrDefault(x => x == FluxType.NoClean);
            SelectedControlledImpendance = ControlledImpendanceValues.FirstOrDefault(x => x == ControlledImpendance.None);
            SelectedTentingForVias = TentingForViasValues.FirstOrDefault(x => x == TentingForVias.None);
            SelectedStackup = StackupValues.FirstOrDefault(x => x == Stackup.Standard);
        }

        #endregion
    }
}
