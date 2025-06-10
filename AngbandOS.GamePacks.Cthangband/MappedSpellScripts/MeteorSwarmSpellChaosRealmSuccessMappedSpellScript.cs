namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MeteorSwarmSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MeteorSwarmChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MeteorStormScript) };
}