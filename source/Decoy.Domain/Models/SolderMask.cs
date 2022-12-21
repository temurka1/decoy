namespace Decoy.Domain.Models
{
    public class SolderMask
    {
        #region Properties

        public string Name { get; set; } = string.Empty;

        public byte R { get; set; }
        
        public byte G { get; set; }

        public byte B { get; set; }

        #endregion
    }
}
