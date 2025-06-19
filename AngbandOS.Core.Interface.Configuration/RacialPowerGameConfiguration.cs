
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RacialPowerGameConfiguration
{
    public virtual string ScriptBindingKey { get; set; }
    public virtual string RaceBindingKey { get; set; }
    public virtual string? CharacterClassBindingKey { get; set; } = null;
}

