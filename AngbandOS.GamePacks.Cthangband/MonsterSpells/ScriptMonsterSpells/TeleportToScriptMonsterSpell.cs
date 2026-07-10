// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportToScriptMonsterSpell : ScriptMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "teleport to");
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone commands you to return.";
    public override string? VsPlayerActionMessage => "{0} commands you to return.";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(SystemScriptsEnum.TeleportToMonsterSpellOnPlayerScript);  
}
