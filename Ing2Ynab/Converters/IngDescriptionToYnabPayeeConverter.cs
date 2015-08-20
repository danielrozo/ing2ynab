namespace Ing2Ynab.Converters
{
    internal class IngDescriptionToYnabPayeeConverter : IIngDescriptionToYnabPayeeConverter
    {
        public string ConvertToPayee(string description)
        {
            int indexOf = description.IndexOf('(') == -1 ? description.Length : description.IndexOf('(');
            return description.Substring(0, indexOf);
        }
    }
}
