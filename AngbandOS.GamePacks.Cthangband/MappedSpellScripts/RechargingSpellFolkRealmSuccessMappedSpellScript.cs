namespace AngbandOS.GamePacks.Cthangband;

internal class RechargingSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RechargingFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RechargeItem60RechargeItemScript) };
}