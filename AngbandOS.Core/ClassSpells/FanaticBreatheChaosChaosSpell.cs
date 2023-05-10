internal class FanaticBreatheChaosChaosSpell : ClassSpell
{
    private FanaticBreatheChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellBreatheChaos);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 220;
}