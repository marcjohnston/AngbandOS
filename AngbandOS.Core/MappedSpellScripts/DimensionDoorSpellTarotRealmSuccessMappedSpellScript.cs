namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DimensionDoorSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DimensionDoorSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DimensionDoorTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CreateDimensionDoorScript) };
}