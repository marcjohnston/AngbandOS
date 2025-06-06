namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CurePoisonSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CurePoisonSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CurePoisonLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CurePoisonScript) };
}