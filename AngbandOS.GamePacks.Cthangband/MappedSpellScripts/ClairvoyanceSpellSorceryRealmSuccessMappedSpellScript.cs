namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ClairvoyanceSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ClairvoyanceSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ClairvoyanceScript) };
}