internal class RangerCureMediumWoundsCorporealSpell : ClassSpell
{
    private RangerCureMediumWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureMediumWounds);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 8;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 3;
}