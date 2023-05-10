[Serializable]
internal class HighMageStairBuildingNatureSpell : ClassSpell
{
    private HighMageStairBuildingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStairBuilding);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 44;
}