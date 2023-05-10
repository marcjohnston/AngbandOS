internal class MageStoneSkinCorporealSpell : ClassSpell
{
    private MageStoneSkinCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellStoneSkin);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}