namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EarthquakeSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EarthquakeSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EarthquakeNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EarthquakeR10Script) };
}