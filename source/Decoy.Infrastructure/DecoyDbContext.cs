namespace Decoy.Infrastructure
{
    using Decoy.Domain.Models;

    public class DecoyDbContext
    {
        #region Properties

        public IEnumerable<Material> Materials { get; }

        public IEnumerable<SurfaceFinishType> SurfaceFinishTypes { get; }

        public IEnumerable<SolderMask> SolderMasks { get; }

        public IEnumerable<SilkscreenColor> SilkscreenColors { get; }

        public IEnumerable<CooperWeight> CooperWeights { get; }

        #endregion

        #region Constructors

        public DecoyDbContext()
        {
            Materials = new List<Material>
            {
                new Material
                {
                    Name = "Arlon",
                    CostImpact = 125.3M,
                    TimeImpact = 0
                },
                new Material
                {
                    Name = "Krypnonite",
                    CostImpact = 10000M,
                    TimeImpact = 10
                }
            };

            SurfaceFinishTypes = new List<SurfaceFinishType>
            {
                new SurfaceFinishType
                {
                    Name = "ENEPIG",
                    TimeImpact = 3,
                    CostImpact = 75
                },
                new SurfaceFinishType
                {
                    Name = "GIPENE",
                    TimeImpact = 75,
                    CostImpact = 3
                }
            };

            SolderMasks = new List<SolderMask>
            {
                new SolderMask
                {
                    Name = "Green",
                    R = 0,
                    G = 255,
                    B = 0
                },
                new SolderMask
                {
                    Name = "Red",
                    R = 255,
                    G = 0,
                    B = 0
                }
            };

            SilkscreenColors = new List<SilkscreenColor>
            {
                new SilkscreenColor
                {
                    Name = "Blue",
                    R = 0,
                    G = 0,
                    B = 255
                },
                new SilkscreenColor
                {
                    Name = "Orange",
                    R = 255,
                    G = 165,
                    B = 0
                }
            };

            CooperWeights = new List<CooperWeight>
            {
                new CooperWeight
                {
                    Value = "1.0oz",
                    IsInner = true
                },
                new CooperWeight
                {
                    Value = "2.0oz",
                    IsInner = true
                },
                new CooperWeight
                {
                    Value = "1.0oz",
                    IsInner = false
                },
                new CooperWeight
                {
                    Value = "2.0oz",
                    IsInner = false
                }
            };
        }

        #endregion
    }
}
