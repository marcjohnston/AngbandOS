namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BlackSleepSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BlackSleepDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSleep1xProjectileScript) };
}