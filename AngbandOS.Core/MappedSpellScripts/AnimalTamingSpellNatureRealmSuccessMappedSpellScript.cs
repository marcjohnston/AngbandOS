namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AnimalTamingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AnimalTamingSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AnimalTamingNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AnimalTrainingScript) };
}