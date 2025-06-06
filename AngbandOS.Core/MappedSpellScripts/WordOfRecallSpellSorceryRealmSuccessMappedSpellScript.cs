namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WordOfRecallSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WordOfRecallSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WordOfRecallSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ToggleRecallScript) };
}