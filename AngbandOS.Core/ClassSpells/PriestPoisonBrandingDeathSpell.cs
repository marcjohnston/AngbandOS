internal class PriestPoisonBrandingDeathSpell : ClassSpell
{
    private PriestPoisonBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellPoisonBranding);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 75;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 30;
}