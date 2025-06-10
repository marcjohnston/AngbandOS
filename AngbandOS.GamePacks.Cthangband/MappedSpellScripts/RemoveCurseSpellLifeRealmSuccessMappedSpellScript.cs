namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RemoveCurseSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RemoveCurseLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RemoveCurseScript) };
}