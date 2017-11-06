namespace AsyncUpload.Models
{
    public class ByteUnit : SizeUnit
    {
        public ByteUnit() : base("B")
        {
            Successor = new KByteUnit();
        }
    }
}