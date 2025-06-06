namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class PrayerSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private PrayerSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(PrayerLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PrayerScript) };
}