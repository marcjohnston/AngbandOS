namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MagicMappingSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MagicMappingSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MagicMappingSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MapAreaScript) };
}