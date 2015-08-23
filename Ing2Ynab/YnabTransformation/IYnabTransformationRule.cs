using Ing2Ynab.Entities;

namespace Ing2Ynab.YnabTransformation
{
    internal interface IYnabTransformationRule
    {
        YnabTransaction Transform(YnabTransaction ynabTransaction);
    }
}
