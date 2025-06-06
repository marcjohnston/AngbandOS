namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MoveBodySpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MoveBodySpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MoveBodyCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MoveBodyScript) };
}