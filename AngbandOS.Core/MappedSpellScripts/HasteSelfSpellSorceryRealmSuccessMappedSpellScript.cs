namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HasteSelfSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HasteSelfSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HasteSelfSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HasteScript) };
}