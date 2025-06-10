namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class LightningBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(LightningBoltNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.LightningBoltScript) };
}