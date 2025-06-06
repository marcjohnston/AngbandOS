namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistPoisonSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistPoisonSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistPoisonDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistPoisonScript) };
}