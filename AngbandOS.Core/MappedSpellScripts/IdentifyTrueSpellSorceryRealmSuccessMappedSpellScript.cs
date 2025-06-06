namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class IdentifyTrueSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private IdentifyTrueSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(IdentifyTrueSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(IdentifyItemFullyScript) };
}