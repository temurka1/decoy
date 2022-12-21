namespace Decoy.Domain.Enums
{
    using System.ComponentModel;

    public enum TentingForVias
    {
        [Description("Both Sides")]
        BothSides,

        [Description("Top Side")]
        TopSide,

        [Description("Bottom Side")]
        BottomSide,

        [Description("None")]
        None
    }
}
