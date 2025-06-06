namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StairBuildingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StairBuildingSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StairBuildingNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CreateStairsScript) };
}