namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class VampirismTrueSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(VampirismTrueDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.VampirismTrueScript) };
}