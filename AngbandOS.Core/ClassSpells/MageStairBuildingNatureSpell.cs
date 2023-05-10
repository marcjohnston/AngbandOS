[Serializable]
internal class MageStairBuildingNatureSpell : ClassSpell
{
    private MageStairBuildingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStairBuilding);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 44;
}