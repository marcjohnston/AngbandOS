internal class RangerHasteCorporealSpell : ClassSpell
{
    private RangerHasteCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHaste);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 34;
    public override int ManaCost => 35;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 4;
}