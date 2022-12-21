namespace Decoy.ViewModels.Quote
{
    using System.Collections.Generic;

    using Prism.Mvvm;

    using Common.Controls;
    using Domain.Models;

    public class ParameterPanelViewModel : BindableBase
    {
        #region Fields

        private LinearGraphData _timeImpactGraphData;
        private LinearGraphData _costImpactGraphData;

        private LinearGraphData _graphData;
        private DetailsViewModel _details;

        private IEnumerable<QuoteItem> _quoteTableData;

        private int _totalTimeImpact;
        private decimal _totalCostImpact;

        private string _impact;

        private bool _isShowTimeImpactChecked;
        private bool _isShowCostImpactChecked;

        #endregion

        #region Properties

        public LinearGraphData GraphData
        {
            get => _graphData;
            set => SetProperty(ref _graphData, value);
        }

        public DetailsViewModel Details
        {
            get => _details;
            set => SetProperty(ref _details, value);
        }

        public string Impact
        {
            get => _impact;
            set => SetProperty(ref _impact, value);
        }

        public bool IsShowTimeImpactChecked
        {
            get => _isShowTimeImpactChecked;
            set
            {
                if (value)
                {
                    SetProperty(ref _isShowTimeImpactChecked, value);

                    _isShowCostImpactChecked = false;
                    RaisePropertyChanged(nameof(IsShowCostImpactChecked));

                    Impact = $"{_totalTimeImpact} days";
                    GraphData = _timeImpactGraphData;
                }
            }
        }

        public bool IsShowCostImpactChecked
        {
            get => _isShowCostImpactChecked;
            set
            {
                if (value)
                {
                    SetProperty(ref _isShowCostImpactChecked, value);

                    _isShowTimeImpactChecked = false;
                    RaisePropertyChanged(nameof(IsShowTimeImpactChecked));

                    Impact = $"${_totalCostImpact}";
                    GraphData = _costImpactGraphData;
                }
            }
        }

        #endregion

        #region Constructors

        public ParameterPanelViewModel()
        {
            _details = new DetailsViewModel();
        }

        #endregion

        #region Methods

        public void Update(IEnumerable<QuoteItem> quoteTableData, int totalTimeImpact, decimal totalCostImpact)
        {
            _quoteTableData = quoteTableData;    
            _totalTimeImpact = totalTimeImpact;
            _totalCostImpact = totalCostImpact;

            _details.Update(quoteTableData);

            UpdateTimeImpactGraphData();
            UpdateCostImpactGraphData();

            IsShowTimeImpactChecked = true;
        }

        private void UpdateTimeImpactGraphData()
        {
            var graphItems = new List<LinearGraphDataItem>();

            foreach (var group in _quoteTableData.GroupBy(x => x.ManufacturingStage))
            {
                var groupTimeImpact = group.Sum(x => x.TimeImpact);
                var percentage = Convert.ToDecimal(groupTimeImpact) / _totalTimeImpact;

                graphItems.Add(new LinearGraphDataItem
                {
                    Description = group.Key,
                    Value = $"{groupTimeImpact} days",
                    Percentage = percentage
                });
            }

            _timeImpactGraphData = new LinearGraphData
            {
                Items = graphItems
            };
        }

        private void UpdateCostImpactGraphData()
        {
            var graphItems = new List<LinearGraphDataItem>();

            foreach (var group in _quoteTableData.GroupBy(x => x.ManufacturingStage))
            {
                var groupCostImpact = group.Sum(x => x.CostImpact);
                var percentage = groupCostImpact / _totalCostImpact;

                graphItems.Add(new LinearGraphDataItem
                {
                    Description = group.Key,
                    Value = $"${groupCostImpact:0,0.00}",
                    Percentage = percentage
                });
            }

            _costImpactGraphData = new LinearGraphData
            {
                Items = graphItems
            };
        }

        #endregion
    }
}
