namespace AngbandOS.GamePacks.Cthangband;

internal class TeleportAwaySpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TeleportAwayTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayAll1xProjectileScript) };
}