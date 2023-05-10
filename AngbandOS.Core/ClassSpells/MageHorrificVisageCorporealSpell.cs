internal class MageHorrificVisageCorporealSpell : ClassSpell
{
    private MageHorrificVisageCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHorrificVisage);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 15;
}