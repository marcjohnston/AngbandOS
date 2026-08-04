namespace AngbandOS.GamePacks.Cthangband;

internal class NonMageCharacterClassManaBurstScriptSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ManaBurstChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageManaBurstScript) };
    public override int? MaximumExperienceLevel => 29;
}
