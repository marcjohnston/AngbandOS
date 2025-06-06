namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureLightWoundsSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureLightWoundsSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureLightWoundsCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureLightWounds2d10Script) };
}