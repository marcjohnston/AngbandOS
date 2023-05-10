[Serializable]
internal class PriestWallOfStoneNatureSpell : ClassSpell
{
    private PriestWallOfStoneNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWallOfStone);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 50;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}