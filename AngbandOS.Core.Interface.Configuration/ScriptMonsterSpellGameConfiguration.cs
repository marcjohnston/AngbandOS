namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ScriptMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on the player. If null, no script will be executed.
    /// </summary>
    public virtual string? ExecuteOnPlayerScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on a monster. If null, no script will be executed.
    /// </summary>
    public virtual string? ExecuteOnMonsterScriptBindingKey { get; set; } = null;
}
