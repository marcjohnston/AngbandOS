namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class YellowSignSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private YellowSignSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(YellowSignSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(YellowSignScript) };
}