namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class PhaseDoorSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private PhaseDoorSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(PhaseDoorSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PhaseDoorScript) };
}