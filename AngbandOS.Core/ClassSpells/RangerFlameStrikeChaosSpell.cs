internal class RangerFlameStrikeChaosSpell : ClassSpell
{
    private RangerFlameStrikeChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlameStrike);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 42;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 42;
}