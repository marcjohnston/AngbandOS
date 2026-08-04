namespace AngbandOS.GamePacks.Cthangband;

internal class IdentifyTrueSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(IdentifyTrueSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.IdentifyItemFullyScript) };
}