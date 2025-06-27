namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NonMageFireBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FireBoltChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NonMageFireBoltOrBeamOfFireScript) };
}
