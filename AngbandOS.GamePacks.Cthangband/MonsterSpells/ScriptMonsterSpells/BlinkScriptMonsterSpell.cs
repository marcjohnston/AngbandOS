// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlinkScriptMonsterSpell : ScriptMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "blink-self");
    public override bool IsIntelligent => true;
    public override bool ProvidesEscape => true;

    public override string? VsPlayerBlindMessage => "You hear someone blink away.";
    public override string? VsPlayerActionMessage => "{0} blinks away.";
    public override string? VsPlayerActionMessageOnInvisibleMonster => null;

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(SystemScriptsEnum.BlinkMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(SystemScriptsEnum.BlinkMonsterSpellOnMonsterScript);
}
