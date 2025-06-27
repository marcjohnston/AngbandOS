namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NonMageCharacterClassOrbOfEntropySpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(OrbOfEntropyDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageOrbOfEntropyProjectileScript) };
}

[Serializable]
internal class NonMageCharacterClassLevel30OrbOfEntropySpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(OrbOfEntropyDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageLevel30OrbOfEntropyProjectileScript) };
}
