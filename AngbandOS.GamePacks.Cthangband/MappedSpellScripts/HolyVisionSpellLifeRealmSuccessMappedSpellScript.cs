namespace AngbandOS.GamePacks.Cthangband;

internal class HolyVisionSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HolyVisionLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.IdentifyItemFullyScript) };
}