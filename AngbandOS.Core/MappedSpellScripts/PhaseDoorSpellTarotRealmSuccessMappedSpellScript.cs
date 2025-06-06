namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class PhaseDoorSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private PhaseDoorSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(PhaseDoorTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PhaseDoorScript) };
}