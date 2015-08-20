namespace Ing2Ynab.Converters
{
    internal interface IIngDescriptionToYnabPayeeConverter
    {
        string ConvertToPayee(string description);
    }
}
