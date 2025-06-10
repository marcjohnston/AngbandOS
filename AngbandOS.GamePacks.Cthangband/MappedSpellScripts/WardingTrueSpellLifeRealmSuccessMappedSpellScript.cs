namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WardingTrueSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WardingTrueLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ElderSignScript), nameof(WardingProjectileScript) };
}