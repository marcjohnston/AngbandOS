namespace AngbandOS.GamePacks.Cthangband;

internal class TeleportLevelSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TeleportLevelSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.TeleportLevelScript) };
}