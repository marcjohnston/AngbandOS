internal class CultistDetectDoorsAndTrapsSorcerySpell : ClassSpell
{
    private CultistDetectDoorsAndTrapsSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectDoorsAndTraps);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 1;
}