namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WordOfDeathSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WordOfDeathDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelLivingAtLos3xProjectileScript) };
}