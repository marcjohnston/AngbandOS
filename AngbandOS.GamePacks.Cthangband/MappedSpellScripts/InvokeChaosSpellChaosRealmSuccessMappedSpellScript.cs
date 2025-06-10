namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class InvokeChaosSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(InvokeChaosChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.InvokeChaosScript) };
}