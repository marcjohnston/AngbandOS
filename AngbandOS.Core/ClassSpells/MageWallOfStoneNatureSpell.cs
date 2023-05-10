[Serializable]
internal class MageWallOfStoneNatureSpell : ClassSpell
{
    private MageWallOfStoneNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWallOfStone);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 45;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 200;
}