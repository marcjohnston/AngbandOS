namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DoorCreationSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DoorCreationSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DoorCreationNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CreateDoorProjectileScript) };
}