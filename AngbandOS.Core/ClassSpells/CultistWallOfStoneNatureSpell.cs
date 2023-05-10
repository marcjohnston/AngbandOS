[Serializable]
internal class CultistWallOfStoneNatureSpell : ClassSpell
{
    private CultistWallOfStoneNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWallOfStone);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 48;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 200;
}