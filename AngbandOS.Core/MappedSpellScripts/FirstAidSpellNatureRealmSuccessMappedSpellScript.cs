namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class FirstAidSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private FirstAidSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(FirstAidNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FirstAidScript) };
}