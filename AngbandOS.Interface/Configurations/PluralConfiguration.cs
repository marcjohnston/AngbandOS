
namespace AngbandOS.Core.Interface;

[Serializable]
public class PluralConfiguration : IConfiguration
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

    public bool IsValid()
    {
        return true;
    }

    public override string ToString()
    {
        return Key;
    }
}