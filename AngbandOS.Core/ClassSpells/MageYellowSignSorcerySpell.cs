internal class MageYellowSignSorcerySpell : ClassSpell
{
    private MageYellowSignSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellYellowSign);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 39;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 160;
}