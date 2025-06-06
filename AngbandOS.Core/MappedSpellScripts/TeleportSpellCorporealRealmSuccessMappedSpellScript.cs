namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf3xScript) };
}