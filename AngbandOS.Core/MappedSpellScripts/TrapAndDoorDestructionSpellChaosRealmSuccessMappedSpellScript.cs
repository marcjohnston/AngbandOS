namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TrapAndDoorDestructionSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TrapAndDoorDestructionSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TrapAndDoorDestructionChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DestroyAdjacentDoorsScript) };
}