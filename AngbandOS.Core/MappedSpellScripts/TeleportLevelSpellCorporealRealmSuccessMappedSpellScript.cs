namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportLevelSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportLevelSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportLevelCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportLevelScript) };
}