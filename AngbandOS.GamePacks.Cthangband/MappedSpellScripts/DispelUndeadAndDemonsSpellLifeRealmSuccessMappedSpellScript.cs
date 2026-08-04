namespace AngbandOS.GamePacks.Cthangband;

internal class DispelUndeadAndDemonsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DispelUndeadAndDemonsLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DispelUndeadAndDemonsScript) };
}