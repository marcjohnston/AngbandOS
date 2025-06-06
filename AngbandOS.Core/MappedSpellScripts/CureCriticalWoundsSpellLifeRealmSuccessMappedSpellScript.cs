namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureCriticalWoundsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureCriticalWoundsSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureCriticalWoundsLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureCriticalWounds8d10Script) };
}