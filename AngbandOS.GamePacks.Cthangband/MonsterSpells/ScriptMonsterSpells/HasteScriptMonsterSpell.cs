// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HasteScriptMonsterSpell : ScriptMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "haste-self");
    public override bool IsIntelligent => true;
    public override bool Hastens => true;

    public override string? VsPlayerActionMessage => "{0} concentrates on {1} body.";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(SystemScriptsEnum.HasteMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(SystemScriptsEnum.HasteMonsterSpellOnMonsterScript);
}
