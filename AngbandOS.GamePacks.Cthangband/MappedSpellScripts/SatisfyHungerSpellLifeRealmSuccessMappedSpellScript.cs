namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SatisfyHungerSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SatisfyHungerLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SatisfyHungerScript) };
}