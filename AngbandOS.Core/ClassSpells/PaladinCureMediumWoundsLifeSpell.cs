internal class PaladinCureMediumWoundsLifeSpell : ClassSpell
{
    private PaladinCureMediumWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureMediumWounds);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 9;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 3;
}