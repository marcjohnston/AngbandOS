internal class PriestCureMediumWoundsCorporealSpell : ClassSpell
{
    private PriestCureMediumWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureMediumWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}