internal class RangerMindVisionCorporealSpell : ClassSpell
{
    private RangerMindVisionCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMindVision);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 8;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 2;
}