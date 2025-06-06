namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureLightWoundsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureLightWoundsSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureLightWoundsLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureLightWounds2d10Script) };
}