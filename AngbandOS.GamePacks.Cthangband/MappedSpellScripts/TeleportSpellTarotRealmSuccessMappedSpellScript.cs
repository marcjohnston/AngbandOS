namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TeleportSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TeleportTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf4xTeleportSelfScript) };
}