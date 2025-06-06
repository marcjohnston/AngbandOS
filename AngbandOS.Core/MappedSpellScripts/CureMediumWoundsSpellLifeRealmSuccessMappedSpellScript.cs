namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureMediumWoundsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureMediumWoundsSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureMediumWoundsLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureMediumWounds4d10Script) };
}