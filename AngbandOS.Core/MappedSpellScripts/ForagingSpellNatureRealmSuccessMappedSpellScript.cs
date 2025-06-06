namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ForagingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ForagingSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ForagingNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SatisfyHungerScript) };
}