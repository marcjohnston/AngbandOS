namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WhirlwindAttackSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WhirlwindAttackNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.WhirlwindAttackScript) };
}