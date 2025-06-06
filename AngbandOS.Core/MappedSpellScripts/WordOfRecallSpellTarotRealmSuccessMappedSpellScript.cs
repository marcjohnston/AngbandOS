namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WordOfRecallSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WordOfRecallSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WordOfRecallTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ToggleRecallScript) };
}