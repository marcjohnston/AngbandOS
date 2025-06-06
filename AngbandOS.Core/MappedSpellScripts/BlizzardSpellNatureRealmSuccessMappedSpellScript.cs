namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BlizzardSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BlizzardSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BlizzardNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BlizzardScript) };
}