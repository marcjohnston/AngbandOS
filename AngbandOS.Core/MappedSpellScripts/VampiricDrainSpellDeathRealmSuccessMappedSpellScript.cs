namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class VampiricDrainSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private VampiricDrainSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(VampiricDrainDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(VampiricDrainScript) };
}