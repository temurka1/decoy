namespace Decoy.Domain.Services
{
    using Decoy.Domain.Models;

    public class QuoteGenerator : IQuoteGenerator
    {
        #region Constants

        private decimal OneBoardCost = 26.9M;

        #endregion

        #region Methods

        public IEnumerable<QuoteItem> GetQuote(ProjectSettings projectSettings)
        {
            var quoteItems = new List<QuoteItem>
            {
                new QuoteItem
                {
                    ManufacturingStage = "Fabrication",
                    Parameter = "Base Fabrication",
                    Value = "61.72x147.84mm, 10 layers",
                    CostImpact = 1097M,
                    TimeImpact = 1,
                    Details = new List<QuoteDetailsItem>
                    {
                        new QuoteDetailsItem
                        {
                            Operation = "Board Thickness",
                            OperationDetails = $"{projectSettings.BoardThickness}mm",
                            CostImpactRating = 4,
                            TimeImpactRating = 1
                        },
                        new QuoteDetailsItem
                        {
                            Operation = "Board Dimensions",
                            OperationDetails = "61.72x147.84mm",
                            CostImpactRating = 4,
                            TimeImpactRating = 1
                        },
                        new QuoteDetailsItem
                        {
                            Operation = "Layers",
                            OperationDetails = "10",
                            CostImpactRating = 3,
                            TimeImpactRating = 2,
                            ValidValues = new List<ValidValue>
                            {
                                new ValidValue
                                {
                                     Value = "up to 8",
                                     CostImpact = 1,
                                     TimeImpact = 1,
                                },
                                new ValidValue
                                {
                                     Value = "up to 18",
                                     CostImpact = 2,
                                     TimeImpact = 2,
                                },                 
                                new ValidValue
                                {
                                     Value = "18-64",
                                     CostImpact = 3,
                                     TimeImpact = 3,
                                }
                            }
                        },
                        new QuoteDetailsItem
                        {
                            Operation = "Number of Holes Per Board",
                            OperationDetails = "40",
                            CostImpactRating = 2,
                            TimeImpactRating = 3
                        }
                    }
                },
                new QuoteItem
                {
                    ManufacturingStage = "Fabrication",
                    Parameter = "Boards Quantity",
                    Value = $"{projectSettings.BoardsQuantity}",
                    CostImpact = OneBoardCost * projectSettings.BoardsQuantity,
                    TimeImpact = 0,
                },
                new QuoteItem
                {
                    ManufacturingStage = "Fabrication",
                    Parameter = "Surface Finish",
                    Value = $"{projectSettings.SufraceFinish.Name}",
                    CostImpact = projectSettings.SufraceFinish.CostImpact,
                    TimeImpact = projectSettings.SufraceFinish.TimeImpact,
                    Details = new List<QuoteDetailsItem>
                    {
                        new QuoteDetailsItem
                        {
                            Operation = "Surface Finish",
                            OperationDetails = $"{projectSettings.SufraceFinish.Name}",
                            CostImpactRating = 3,
                            TimeImpactRating = 3,
                        }
                    }
                },
                new QuoteItem
                {
                    ManufacturingStage = "Fabrication",
                    Parameter = "Material",
                    Value = $"{projectSettings.Material.Name}",
                    CostImpact = projectSettings.Material.CostImpact,
                    TimeImpact = projectSettings.Material.TimeImpact,
                    Details = new List<QuoteDetailsItem>
                    {
                        new QuoteDetailsItem
                        {
                            Operation = "Material",
                            OperationDetails = $"{projectSettings.Material.Name}",
                            CostImpactRating = 3,
                            TimeImpactRating = 4,
                        }
                    }
                },

                new QuoteItem
                {
                    ManufacturingStage = "Assembly",
                    Parameter = "Packages",
                    Value = "Package on Packages",
                    CostImpact = 2679M,
                    TimeImpact = 1,
                    Details = new List<QuoteDetailsItem>
                    {
                        new QuoteDetailsItem
                        {
                            Operation = "Packaging",
                            OperationDetails = $"{projectSettings.BoardsQuantity} packages",
                            CostImpactRating = 1,
                            TimeImpactRating = 2,
                        }
                    }
                },                
                new QuoteItem
                {
                    ManufacturingStage = "Assembly",
                    Parameter = "Processes",
                    Value = "Split Assembly",
                    CostImpact = 720.50M,
                    TimeImpact = 0,
                },

                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Microchip A720",
                    Value = "2",
                    CostImpact = 480.64M,
                    TimeImpact = 0,
                    Details = new List<QuoteDetailsItem>
                    {
                        new QuoteDetailsItem
                        {
                            Operation = "Soldering",
                            OperationDetails = $"7",
                            CostImpactRating = 1,
                            TimeImpactRating = 3,
                        }
                    }
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Microchip A720-22K3",
                    Value = "5",
                    CostImpact = 220.12M,
                    TimeImpact = 0,
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Microchip BS2",
                    Value = "6",
                    CostImpact = 220.12M,
                    TimeImpact = 0,
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Microchip BS",
                    Value = "2",
                    CostImpact = 220.12M,
                    TimeImpact = 0,
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Microchip TT2",
                    Value = "65",
                    CostImpact = 220.12M,
                    TimeImpact = 0,
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Microchip TT22",
                    Value = "6",
                    CostImpact = 220.12M,
                    TimeImpact = 0,
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Microchip M28",
                    Value = "13",
                    CostImpact = 220.12M,
                    TimeImpact = 0,
                }
            };

            if (projectSettings.Material.Name == "Krypnonite")
            {
                quoteItems.Add(new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "One Superman Himself",
                    Value = "1",
                    CostImpact = 0,
                    TimeImpact = 0,
                });
            }

            return quoteItems;
        }

        #endregion
    }
}
