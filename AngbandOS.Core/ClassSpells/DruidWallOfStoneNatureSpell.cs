internal class DruidWallOfStoneNatureSpell : ClassSpell
{
    private DruidWallOfStoneNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWallOfStone);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 44;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 200;
}