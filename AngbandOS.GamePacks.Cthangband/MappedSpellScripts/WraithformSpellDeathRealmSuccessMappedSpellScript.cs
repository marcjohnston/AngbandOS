namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WraithformSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WraithformDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EtherealnessXO2dX02TimerScript) };
}