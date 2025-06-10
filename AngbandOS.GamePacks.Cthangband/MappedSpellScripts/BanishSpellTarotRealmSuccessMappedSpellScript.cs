namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BanishSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BanishTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayAllAtLos4xProjectileScript) };
}