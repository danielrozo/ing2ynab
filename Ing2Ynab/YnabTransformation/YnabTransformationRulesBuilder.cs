using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ing2Ynab.YnabTransformation
{
    internal class YnabTransformationRulesBuilder
    {
        public IEnumerable<IYnabTransformationRule> BuildConversionRules()
        {
            return BuildPayeeTransformationRules().Concat(BuildCategoryTransformationRules());
        }

        private IList<IYnabTransformationRule> BuildPayeeTransformationRules()
        {
            var jsonData = File.ReadAllText("UserPreferences\\PayeeMapping.json");

            var rules = JsonConvert.DeserializeObject<List<PayeeTransformationRule>>(jsonData);

            return new List<IYnabTransformationRule>(rules);
        }

        private IList<IYnabTransformationRule> BuildCategoryTransformationRules()
        {
            var jsonData = File.ReadAllText("UserPreferences\\CategoryMapping.json");

            var rules = JsonConvert.DeserializeObject<List<CategoryTransformationRule>>(jsonData);

            return new List<IYnabTransformationRule>(rules);
        }
    }
}
