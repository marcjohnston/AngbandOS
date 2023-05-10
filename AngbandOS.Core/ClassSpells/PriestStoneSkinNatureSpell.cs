internal class PriestStoneSkinNatureSpell : ClassSpell
{
    private PriestStoneSkinNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneSkin);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 13;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 120;
}