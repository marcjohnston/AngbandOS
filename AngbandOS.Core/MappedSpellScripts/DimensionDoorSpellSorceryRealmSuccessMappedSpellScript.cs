namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DimensionDoorSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DimensionDoorSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DimensionDoorSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CreateDimensionDoorScript) };
}