namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TeleportSelfSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TeleportSelfChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf5xTeleportSelfScript) };
}