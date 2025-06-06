namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RestorationSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RestorationSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RestorationLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RestorationScript) };
}