internal class PriestWordOfRecallCorporealSpell : ClassSpell
{
    private PriestWordOfRecallCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellWordOfRecall);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 27;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 19;
}