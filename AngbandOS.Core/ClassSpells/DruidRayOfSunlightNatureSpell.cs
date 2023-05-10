[Serializable]
internal class DruidRayOfSunlightNatureSpell : ClassSpell
{
    private DruidRayOfSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellRayOfSunlight);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 5;
}