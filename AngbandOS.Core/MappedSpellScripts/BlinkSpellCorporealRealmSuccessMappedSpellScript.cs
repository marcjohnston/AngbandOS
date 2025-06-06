namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BlinkSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BlinkSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BlinkCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PhaseDoorScript) };
}