namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RechargingSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RechargingSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RechargeItem60RechargeItemScript) };
}