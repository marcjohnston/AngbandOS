namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MassSleepSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MassSleepSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSleepAtLos1xProjectileScript) };
}