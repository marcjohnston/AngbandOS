
using System.Diagnostics;

namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RacePowerGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, CharacterClassBindingKey, nameof(RacePowerGameConfiguration)}; // CONFIRMED, TODO: WHY FIXED 3RD KEY?

    public virtual string ScriptBindingKey { get; set; }
    public virtual string RaceBindingKey { get; set; }
    public virtual string? CharacterClassBindingKey { get; set; } = null;
}

