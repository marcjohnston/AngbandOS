namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WhirlpoolSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WhirlpoolSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WhirlpoolNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WhirlpoolScript) };
}