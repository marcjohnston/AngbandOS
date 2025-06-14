namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NonMageChaosBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ChaosBoltChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NonMageChaosBoltScript) };
}
