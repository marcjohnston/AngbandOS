namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureLightWoundsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureLightWoundsLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureLightWounds2d10Script) };
}