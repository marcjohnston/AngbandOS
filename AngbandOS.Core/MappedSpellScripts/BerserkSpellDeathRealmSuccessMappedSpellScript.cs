namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BerserkSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BerserkSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BerserkDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SuperHeroism1D25P25ResetFearAndHeal30Script) };
}