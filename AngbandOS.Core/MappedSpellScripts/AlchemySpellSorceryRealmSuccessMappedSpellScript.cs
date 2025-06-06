namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AlchemySpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AlchemySpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AlchemySorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AlchemyScript) };
}