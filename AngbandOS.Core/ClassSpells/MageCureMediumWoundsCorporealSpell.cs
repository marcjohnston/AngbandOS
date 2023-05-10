[Serializable]
internal class MageCureMediumWoundsCorporealSpell : ClassSpell
{
    private MageCureMediumWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureMediumWounds);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}