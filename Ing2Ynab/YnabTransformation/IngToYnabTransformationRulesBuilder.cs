using System.Collections.Generic;
using System.Linq;

namespace Ing2Ynab.YnabTransformation
{
    internal class IngToYnabTransformationRulesBuilder
    {
        //takes a JSON, builds an IEnumerable<IIngToYnabConversionRule>
        public IEnumerable<IYnabTransformationRule> BuildConversionRules()
        {
            return BuildPayeeTransformationRules().Concat(BuildCategoryTransformationRules());
        }

        private IList<IYnabTransformationRule> BuildPayeeTransformationRules()
        {
            return new List<IYnabTransformationRule>
            {
                new PayeeTransformationRule("Amazon EU", "Amazon")
            };
        }

        private IList<IYnabTransformationRule> BuildCategoryTransformationRules()
        {
            return new List<IYnabTransformationRule>
            {
                new CategoryTransformationRule("libros musica juegos", "Books music and games")
            };
        }
    }
}
