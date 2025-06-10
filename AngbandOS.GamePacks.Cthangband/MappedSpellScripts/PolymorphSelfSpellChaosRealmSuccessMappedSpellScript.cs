namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class PolymorphSelfSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(PolymorphSelfChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.PolymorphSelfScript) };
}