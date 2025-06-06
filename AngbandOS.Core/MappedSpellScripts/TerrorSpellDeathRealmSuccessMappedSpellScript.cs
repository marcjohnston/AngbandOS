namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TerrorSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TerrorSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TerrorDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TurnAllAtLos1xp30ProjectileScript) };
}