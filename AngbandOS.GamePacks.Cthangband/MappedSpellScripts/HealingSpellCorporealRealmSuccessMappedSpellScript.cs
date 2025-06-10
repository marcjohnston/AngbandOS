namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HealingSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HealingCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.Healing300ResetStunAndBleedingScript) };
}