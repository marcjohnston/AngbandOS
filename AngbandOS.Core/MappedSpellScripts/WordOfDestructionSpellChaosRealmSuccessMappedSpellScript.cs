namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WordOfDestructionSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WordOfDestructionSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WordOfDestructionChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WordOfDestructionScript) };
}