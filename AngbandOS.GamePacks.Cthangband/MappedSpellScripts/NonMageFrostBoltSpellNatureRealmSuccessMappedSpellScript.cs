namespace AngbandOS.GamePacks.Cthangband;

internal class NonMageFrostBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FrostBoltNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NonMageFrostBoltScript) };
}
