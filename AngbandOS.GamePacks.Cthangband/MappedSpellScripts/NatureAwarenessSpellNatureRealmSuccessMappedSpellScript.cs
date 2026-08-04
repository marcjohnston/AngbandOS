namespace AngbandOS.GamePacks.Cthangband;

internal class NatureAwarenessSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(NatureAwarenessNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NatureAwarenessScript) };
}