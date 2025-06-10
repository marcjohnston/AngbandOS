namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DivineInterventionSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DivineInterventionLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DivineInterventionScript) };
}