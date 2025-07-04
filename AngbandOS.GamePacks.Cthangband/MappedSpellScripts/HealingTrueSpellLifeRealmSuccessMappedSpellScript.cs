namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HealingTrueSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HealingTrueLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HealingTrueScript) };
}