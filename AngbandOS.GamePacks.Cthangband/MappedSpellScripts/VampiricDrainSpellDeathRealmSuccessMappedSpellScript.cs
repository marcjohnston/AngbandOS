namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class VampiricDrainSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(VampiricDrainDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.VampiricDrainScript) };
}