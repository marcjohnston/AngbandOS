using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SyllableSetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string[]",
        Title = "Beginning Syllables",
        Summary = "Specifies the syllables that can begin generated names.")]
    public virtual string[] BeginningSyllables { get; set; }

    [ConfigurationProperty("string[]",
        Title = "Middle Syllables",
        Summary = "Specifies the syllables that can appear in the middle of generated names.")]
    public virtual string[] MiddleSyllables { get; set; }

    [ConfigurationProperty("string[]",
        Title = "Ending Syllables",
        Summary = "Specifies the syllables that can end generated names.")]
    public virtual string[] EndingSyllables { get; set; }
}
