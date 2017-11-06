namespace AsyncUpload.Models
{
    public class KByteUnit : SizeUnit
    {
        public KByteUnit() : base("KB")
        {
            Successor = new MByteUnit();
        }
    }
}