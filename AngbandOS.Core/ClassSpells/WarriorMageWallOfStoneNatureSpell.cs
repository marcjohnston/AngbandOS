internal class WarriorMageWallOfStoneNatureSpell : ClassSpell
{
    private WarriorMageWallOfStoneNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWallOfStone);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 48;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 200;
}