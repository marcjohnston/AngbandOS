
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public abstract class NonCompositeSingletonGameConfiguration : IGetKeyGameConfiguration
{
    /// <summary>
    /// Returns the unique key as provided by the game pack or configuration for this singleton; or null, to use the name of the class as the key.
    /// </summary>
    /// <remarks>
    /// This key uses the non-composite singleton key pattern.
    /// </remarks>
    public virtual string? Key { get; set; } = null;
    /// <summary>
    /// Returns the unique key for this singleton.
    /// </summary>
    /// <remarks>
    /// This GetKey uses the non-composite singleton key pattern.
    /// </remarks>
    public string GetKey => Key ?? GetType().Name;
}
