internal class CultistYellowSignSorcerySpell : ClassSpell
{
    private CultistYellowSignSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellYellowSign);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 35;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 160;
}