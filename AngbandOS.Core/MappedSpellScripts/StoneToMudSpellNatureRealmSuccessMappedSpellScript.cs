namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StoneToMudSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StoneToMudSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StoneToMudNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(StoneToMudScript) };
}