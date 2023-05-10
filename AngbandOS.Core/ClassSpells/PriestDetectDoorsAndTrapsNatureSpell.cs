internal class PriestDetectDoorsAndTrapsNatureSpell : ClassSpell
{
    private PriestDetectDoorsAndTrapsNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDetectDoorsAndTraps);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 1;
}