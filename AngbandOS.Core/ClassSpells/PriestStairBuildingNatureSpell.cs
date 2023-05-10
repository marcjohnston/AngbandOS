internal class PriestStairBuildingNatureSpell : ClassSpell
{
    private PriestStairBuildingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStairBuilding);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 44;
}