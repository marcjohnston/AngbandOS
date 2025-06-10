namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ProtectFromCorrosionSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ProtectFromCorrosionNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RustProofScript) };
}