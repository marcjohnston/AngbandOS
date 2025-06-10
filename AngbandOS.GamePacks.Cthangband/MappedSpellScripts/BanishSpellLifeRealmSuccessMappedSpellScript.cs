namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BanishSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BanishLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayEvilAtLosByGod100ProjectileScript) };
}