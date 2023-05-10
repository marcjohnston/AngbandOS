internal class MageCureMediumWoundsLifeSpell : ClassSpell
{
    private MageCureMediumWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureMediumWounds);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 3;
}