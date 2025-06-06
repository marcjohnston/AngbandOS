namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonAnimalSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonAnimalSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonAnimalTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AnimalSummonWeightedRandom) };
}