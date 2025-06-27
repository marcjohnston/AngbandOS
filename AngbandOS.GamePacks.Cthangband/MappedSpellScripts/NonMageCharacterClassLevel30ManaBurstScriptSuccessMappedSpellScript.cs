namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NonMageCharacterClassLevel30ManaBurstScriptSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ManaBurstChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageLevel30ManaBurstScript) };
    public override int? MinimumExperienceLevel => 30;
}
