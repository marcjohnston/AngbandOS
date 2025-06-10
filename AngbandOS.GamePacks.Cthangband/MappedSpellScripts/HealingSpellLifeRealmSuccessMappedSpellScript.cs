namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HealingSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HealingLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.Healing300ResetStunAndBleedingScript) };
}