namespace AsyncUpload.Models
{
    public class MByteUnit : SizeUnit
    {
        public MByteUnit() : base("MB")
        {
            Successor = new GByteUnit();
        }
    }
}