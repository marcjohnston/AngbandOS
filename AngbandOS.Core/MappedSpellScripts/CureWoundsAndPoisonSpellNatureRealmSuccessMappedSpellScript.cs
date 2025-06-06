namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureWoundsAndPoisonSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureWoundsAndPoisonSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureWoundsAndPoisonNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureWoundsAndPoisonScript) };
}