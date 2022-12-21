namespace Decoy.Domain.Models
{
    using Decoy.Domain.Enums;

    public class ProjectSettings
    {
        #region Properties

        public string Name { get; set; }

        public string Zipcode { get; set; }

        public int BoardsQuantity { get; set; }

        public decimal BoardThickness { get; set; }

        public Material Material { get; set; }

        public SurfaceFinishType SufraceFinish { get; set; }

        public SolderMask SolderMask { get; set; }

        public LeadFree LeadFree { get; set; }

        public IpcClass IpcClass { get; set; }

        public Itar Itar { get; set; }

        public FluxType FluxType { get; set; }

        public ControlledImpendance ControlledImpendance { get; set; }

        public TentingForVias TentingForVias { get; set; }

        public Stackup Stackup { get; set; }

        public CooperWeight InnerLayerCooperWeight { get; set; }

        public CooperWeight OuterLayerCooperWeight { get; set; }

        public SilkscreenColor SilkscreenColor { get; set; }

        public string Notes { get; set; }

        #endregion
    }
}
