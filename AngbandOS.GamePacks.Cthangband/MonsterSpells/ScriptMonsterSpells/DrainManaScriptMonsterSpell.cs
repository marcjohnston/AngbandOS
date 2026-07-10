// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DrainManaScriptMonsterSpell : ScriptMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "drain mana");
    /// <summary>
    /// Returns null, because the drain mana process cannot be seen.  If the player cannot see either monster, the player will not have
    /// any message indicating such.
    /// </summary>
    public override string? VsPlayerBlindMessage => null;

    /// <summary>
    /// Returns the message rendered to the player when a monster drains energy from another monster and the player sees it.
    /// </summary>
    public override string? VsMonsterSeenMessage => "{0} draws psychic energy from {3}.";

    public override bool DrainsMana => true;
    public override bool Annoys => true;


    public override string? ExecuteOnPlayerScriptBindingKey => nameof(SystemScriptsEnum.DrainManaMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(SystemScriptsEnum.DrainManaMonsterSpellOnMonsterScript);
}
