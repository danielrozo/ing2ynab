namespace Ing2Ynab
{
    class Program
    {
        static void Main(string[] args)
        {
            // say the number of weeks you want to import for into YNAB
            /*configure an XML/JSON that the app reads and uses to transform descriptions into payees
                and select if they want to include the description into the Memo field.

                Something like:
                { 
                    replacementRules: [
                        {
                            contains: "Amazon.ES"
                            replace: "Amazon"
                            category: "Dumb shit"
                            includeOriginalInMemo: true
                        },
                        {
                            //....
                        }
                    ]
                }
            */
        }
    }
}
