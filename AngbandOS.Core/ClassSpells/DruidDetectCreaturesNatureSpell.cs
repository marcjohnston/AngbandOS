internal class DruidDetectCreaturesNatureSpell : ClassSpell
{
    private DruidDetectCreaturesNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDetectCreatures);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 4;
}