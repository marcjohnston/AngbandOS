namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MassSleepSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MassSleepSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MassSleepSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSleepAtLos1xProjectileScript) };
}