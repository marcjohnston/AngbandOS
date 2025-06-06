namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class LightAreaSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private LightAreaSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(LightAreaSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(LightAreaScript) };
}