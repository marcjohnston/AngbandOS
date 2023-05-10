internal class DruidDetectDoorsAndTrapsNatureSpell : ClassSpell
{
    private DruidDetectDoorsAndTrapsNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDetectDoorsAndTraps);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 1;
}