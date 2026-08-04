namespace AngbandOS.GamePacks.Cthangband;

internal class MassCarnageSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MassCarnageDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MassCarnageScript) };
}