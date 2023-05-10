internal class FanaticFlameStrikeChaosSpell : ClassSpell
{
    private FanaticFlameStrikeChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlameStrike);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 37;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 40;
}