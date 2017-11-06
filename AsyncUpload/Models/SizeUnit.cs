using System;

namespace AsyncUpload.Models
{
    /// <summary>
    /// Estas clases únicamente devuelven el valor en la unidad de almacenamiento más grande posible.
    /// Para esto, se usa el patrón de "cadena de responsabilidad".
    /// http://www.dofactory.com/net/chain-of-responsibility-design-pattern
    /// </summary>
    public abstract class SizeUnit
    {
        protected SizeUnit Successor { private get; set; }
        protected string Unit { get; set; }
        public decimal Value { get; set; }

        protected SizeUnit(string unit)
        {
            Unit = unit;
        }

        public string Get()
        {
            decimal result = Math.Round(Value / 1024);
            if (result > 0 && Successor != null)
            {
                Successor.Value = result;
                return Successor.Get();
            }
            return Value + Unit;
        }
    }
}