namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NaturesWrathSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(NaturesWrathNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NaturesWrathScript) };
}