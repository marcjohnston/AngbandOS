namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureCriticalWoundsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureCriticalWoundsLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureCriticalWounds8d10Script) };
}