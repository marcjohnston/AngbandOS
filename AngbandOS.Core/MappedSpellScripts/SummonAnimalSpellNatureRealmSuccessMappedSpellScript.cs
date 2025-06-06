namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonAnimalSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonAnimalSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonAnimalNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FriendlyAnimalSummonScript) };
}