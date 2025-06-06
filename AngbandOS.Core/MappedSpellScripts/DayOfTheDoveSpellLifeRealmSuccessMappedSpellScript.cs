namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DayOfTheDoveSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DayOfTheDoveSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DayOfTheDoveLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ControlAnimalAtLos2xProjectileScript) };
}