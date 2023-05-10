internal class MageHasteCorporealSpell : ClassSpell
{
    private MageHasteCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHaste);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 12;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}