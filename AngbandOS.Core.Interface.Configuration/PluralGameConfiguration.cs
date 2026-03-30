
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class PluralGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns the pluralized version of the key.
    /// the class.
    /// </summary>
    public virtual string PluralForm { get; set; }
}
