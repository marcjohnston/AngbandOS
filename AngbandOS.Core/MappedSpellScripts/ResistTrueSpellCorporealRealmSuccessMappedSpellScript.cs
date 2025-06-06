namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistTrueSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistTrueSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistTrueCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistTrueScript) };
}