namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AnimalFriendshipSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AnimalFriendshipSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AnimalFriendshipNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ControlAnimalAtLos2xProjectileScript) };
}