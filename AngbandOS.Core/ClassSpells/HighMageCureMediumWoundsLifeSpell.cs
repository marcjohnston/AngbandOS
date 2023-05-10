[Serializable]
internal class HighMageCureMediumWoundsLifeSpell : ClassSpell
{
    private HighMageCureMediumWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureMediumWounds);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 3;
}