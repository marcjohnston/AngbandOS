namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class FireBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FireBoltChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.FireBoltOrBeamOfFireScript) };
}