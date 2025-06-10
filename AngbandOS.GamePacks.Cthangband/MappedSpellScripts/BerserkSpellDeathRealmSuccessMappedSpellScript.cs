namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BerserkSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BerserkDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SuperHeroism1D25P25ResetFearAndHeal30Script) };
}