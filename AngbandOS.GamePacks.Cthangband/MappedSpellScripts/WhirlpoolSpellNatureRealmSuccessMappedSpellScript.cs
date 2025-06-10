namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WhirlpoolSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WhirlpoolNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.WhirlpoolScript) };
}