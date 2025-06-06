namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MindBlastSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MindBlastSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MindBlastTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MindBlastScript) };
}