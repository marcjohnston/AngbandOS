internal class PriestCureMediumWoundsLifeSpell : ClassSpell
{
    private PriestCureMediumWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureMediumWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 32;
    public override int FirstCastExperience => 4;
}