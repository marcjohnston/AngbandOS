[Serializable]
internal class WarriorMageMindVisionCorporealSpell : ClassSpell
{
    private WarriorMageMindVisionCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMindVision);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}