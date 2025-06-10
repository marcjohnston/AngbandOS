namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AlterRealitySpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(AlterRealityChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.AlterRealityScript) };
}