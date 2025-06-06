namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SelfKnowledgeSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SelfKnowledgeSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SelfKnowledgeSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SelfKnowledgeScript) };
}