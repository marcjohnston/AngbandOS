// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportSelfScriptMonsterSpell : ScriptMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "teleport-self");
    public override bool IsIntelligent => true;
    public override bool ProvidesEscape => true;

    /// <summary>
    /// Returns null, because a blind player cannot see or hear this action.
    /// </summary>
    public override string? VsPlayerBlindMessage => null;

    /// <summary>
    /// Returns a message indicating that the player noticed the monster teleported away.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override string? VsPlayerActionMessage => "{0} teleports away.";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(SystemScriptsEnum.TeleportSelfMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(SystemScriptsEnum.TeleportSelfMonsterSpellOnMonsterScript);
}
