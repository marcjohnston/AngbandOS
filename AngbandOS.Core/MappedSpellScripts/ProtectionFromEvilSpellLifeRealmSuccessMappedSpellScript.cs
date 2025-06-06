namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ProtectionFromEvilSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ProtectionFromEvilSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ProtectionFromEvilLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ProtectionFromEvilScript) };
}