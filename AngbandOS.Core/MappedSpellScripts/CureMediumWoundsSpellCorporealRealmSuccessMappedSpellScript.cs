namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureMediumWoundsSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureMediumWoundsSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureMediumWoundsCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureMediumWounds4d10Script) };
}