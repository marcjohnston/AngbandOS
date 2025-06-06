namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class PhantasmalServantSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private PhantasmalServantSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(PhantasmalServantTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PhantasmalServantScript) };
}