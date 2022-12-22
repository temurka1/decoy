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
            var materialValidValues = new List<ValidValue>
            {
                new ValidValue
                {
                    Id = new Guid("BDFC5771-AF67-4336-9255-5A78389B110C"),
                    Value = "Arlon",
                    CostImpactRating = 3,
                    TimeImpactRating = 3,
                },
                new ValidValue
                {
                    Id = new Guid("786AC9DE-4411-4579-85FA-DEEDDB7E8774"),
                    Value = "Krypnonite",
                    CostImpactRating = 5,
                    TimeImpactRating = 4,
                },
            };

            var selectedMaterialValue = materialValidValues.First(x => x.Value == projectSettings.Material.Name);

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
                            Value = $"{projectSettings.BoardThickness}mm",
                            CostImpactRating = 4,
                            TimeImpactRating = 1
                        },
                        new QuoteDetailsItem
                        {
                            Operation = "Board Dimensions",
                            Value = "61.72x147.84mm",
                            CostImpactRating = 4,
                            TimeImpactRating = 1
                        },
                        new QuoteDetailsItem
                        {
                            Operation = "Layers",
                            Value = "10",
                            ValueId = new Guid("1ADD562F-A2C8-4C85-A390-EB6A1E88E2FD"),
                            CostImpactRating = 3,
                            TimeImpactRating = 2,
                            ValidValues = new List<ValidValue>
                            {
                                new ValidValue
                                {
                                    Id = new Guid("A52FDD3A-E4A5-458B-A074-6E511B76B0B4"),
                                    Value = "up to 8",
                                    CostImpactRating = 1,
                                    TimeImpactRating = 1,
                                },
                                new ValidValue
                                {
                                    Id = new Guid("1ADD562F-A2C8-4C85-A390-EB6A1E88E2FD"),
                                    Value = "up to 18",
                                    CostImpactRating = 2,
                                    TimeImpactRating = 2,
                                },                 
                                new ValidValue
                                {
                                    Id = new Guid("A32A66C4-108A-40D7-B166-F3BBED30B6EA"),
                                    Value = "18-64",
                                    CostImpactRating = 3,
                                    TimeImpactRating = 3,
                                }
                            }
                        },
                        new QuoteDetailsItem
                        {
                            Operation = "Number of Holes Per Board",
                            Value = "40",
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
                            Value = $"{projectSettings.SufraceFinish.Name}",
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
                            Value = projectSettings.Material.Name,
                            ValueId = selectedMaterialValue.Id,
                            CostImpactRating = selectedMaterialValue.CostImpactRating,
                            TimeImpactRating = selectedMaterialValue.TimeImpactRating,
                            ValidValues = materialValidValues
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
                            Value = $"{projectSettings.BoardsQuantity} packages",
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
                            Value = $"7",
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
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "LOPATA-28",
                    Value = "22",
                    CostImpact = 1420.26M,
                    TimeImpact = 0,
                },
                new QuoteItem
                {
                    ManufacturingStage = "Components",
                    Parameter = "Stonefist L42",
                    Value = "42",
                    CostImpact = 879M,
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
