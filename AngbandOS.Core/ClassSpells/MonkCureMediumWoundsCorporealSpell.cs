[Serializable]
internal class MonkCureMediumWoundsCorporealSpell : ClassSpell
{
    private MonkCureMediumWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureMediumWounds);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}