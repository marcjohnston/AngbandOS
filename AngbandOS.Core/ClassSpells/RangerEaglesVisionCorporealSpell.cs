internal class RangerEaglesVisionCorporealSpell : ClassSpell
{
    private RangerEaglesVisionCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellEaglesVision);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 6;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 2;
}