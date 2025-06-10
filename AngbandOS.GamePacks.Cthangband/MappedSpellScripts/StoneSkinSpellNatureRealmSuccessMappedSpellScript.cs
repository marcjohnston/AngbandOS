namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class StoneSkinSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(StoneSkinNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.StoneSkinScript) };
}