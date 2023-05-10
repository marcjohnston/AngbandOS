internal class PriestHorrificVisageCorporealSpell : ClassSpell
{
    private PriestHorrificVisageCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHorrificVisage);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 15;
}