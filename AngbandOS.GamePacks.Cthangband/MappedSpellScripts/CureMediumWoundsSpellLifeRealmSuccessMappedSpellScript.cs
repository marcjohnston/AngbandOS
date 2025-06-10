namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureMediumWoundsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureMediumWoundsLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureMediumWounds4d10Script) };
}