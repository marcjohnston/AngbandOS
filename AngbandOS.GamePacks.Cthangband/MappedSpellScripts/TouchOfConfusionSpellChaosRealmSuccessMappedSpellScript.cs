namespace AngbandOS.GamePacks.Cthangband;

internal class TouchOfConfusionSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TouchOfConfusionChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.TouchOfConfusionScript) };
}