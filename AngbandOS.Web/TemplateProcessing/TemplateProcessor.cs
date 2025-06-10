using System.Reflection;
namespace AngbandOS.Web.TemplateProcessing
{
    public class TemplateProcessor
    {
        /// <summary>
        /// Generates a templated email with macro processing.
        /// Templates specify replaceable macros by delimiting the macro name with curly braces {}.  E.g. {email-confirmation-url} will be replaced with the macro value.
        /// </summary>
        /// <param name="template">The name of the template to use.  This name must be the filename.html (excluding the .html file extension) that is located in the /EmailTemplates folder.</param>
        /// <param name="macros">The dictionary of supported macros and the value.  E.g. KeyValuePair<string, string>("email-confirmation-url", "http://angbandos.skarstech.com/Identity/Account/ConfirmEmail?userId=&amp;code=") will replace the macro with the link.</param>
        /// <returns></returns>
        public string GenerateContent(string template, Dictionary<string, string> macros)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] names = assembly.GetManifestResourceNames();
            string resourceName = $"AngbandOS.Web.TemplateProcessing.{template}.html";
            using (Stream ms = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string htmlText = reader.ReadToEnd();
                    while (true)
                    {
                        int startPos = htmlText.IndexOf("{");
                        if (startPos == -1)
                            break;
                        int endPos = htmlText.IndexOf("}", startPos);
                        int length = endPos - startPos + 1;
                        string macroName = htmlText.Substring(startPos + 1, length - 2);
                        if (!macros.TryGetValue(macroName, out string? macroValue))
                            throw new Exception($"Macro '{macroName}' not found.");
                        htmlText = $"{htmlText.Substring(0, startPos)}{macroValue}{htmlText.Substring(startPos + length)}";
                    }
                    return htmlText;
                }
            }
        }
    }
}
