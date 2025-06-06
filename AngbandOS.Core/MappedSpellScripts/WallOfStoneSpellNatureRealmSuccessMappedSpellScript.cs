namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WallOfStoneSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WallOfStoneSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WallOfStoneNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WallOfStoneScript) };
}