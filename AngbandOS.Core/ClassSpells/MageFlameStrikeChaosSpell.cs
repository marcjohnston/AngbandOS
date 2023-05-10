internal class MageFlameStrikeChaosSpell : ClassSpell
{
    private MageFlameStrikeChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlameStrike);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 34;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 40;
}