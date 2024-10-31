
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class PluralGameConfiguration
{
    /// <summary>
    /// Returns the capitalized singular version of the noun.
    /// </summary>
    public virtual string Key { get; set; }

    /// <summary>
    /// Returns the pluralized version of the key.
    /// the class.
    /// </summary>
    public virtual string PluralForm { get; set; }
}