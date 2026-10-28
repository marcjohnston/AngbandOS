using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Syllable Set",
    EntityNoun = "syllable set")]
public class SyllableSetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Beginning Syllables",
        Summary = "Specifies the syllables that can begin generated names.",
        DataType = "string[]")]
    public virtual string[] BeginningSyllables { get; set; }

    [ConfigurationMetadata(
        Title = "Middle Syllables",
        Summary = "Specifies the syllables that can appear in the middle of generated names.",
        DataType = "string[]")]
    public virtual string[] MiddleSyllables { get; set; }

    [ConfigurationMetadata(
        Title = "Ending Syllables",
        Summary = "Specifies the syllables that can end generated names.",
        DataType = "string[]")]
    public virtual string[] EndingSyllables { get; set; }
}
