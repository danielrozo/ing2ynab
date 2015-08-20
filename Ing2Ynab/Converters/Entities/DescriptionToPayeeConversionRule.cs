namespace Ing2Ynab.Converters.Entities
{
    internal class DescriptionToPayeeConversionRule
    {
        public string DescriptionContains { get; set; }
        public string PayeeReplacement { get; set; }
    }
}
