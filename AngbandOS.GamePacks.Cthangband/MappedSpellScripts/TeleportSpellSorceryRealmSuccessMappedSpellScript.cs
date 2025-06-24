namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TeleportSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TeleportSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf5xTeleportSelfScript) };
}