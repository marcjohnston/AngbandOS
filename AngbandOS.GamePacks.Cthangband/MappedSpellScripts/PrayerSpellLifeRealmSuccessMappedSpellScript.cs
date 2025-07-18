namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class PrayerSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(PrayerLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Blessing1d48p48TimerScript) };
}