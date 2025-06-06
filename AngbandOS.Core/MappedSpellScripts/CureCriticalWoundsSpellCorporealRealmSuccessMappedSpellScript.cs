namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureCriticalWoundsSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureCriticalWoundsSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureCriticalWoundsCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureCriticalWounds8d10Script) };
}