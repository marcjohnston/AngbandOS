[Serializable]
internal class DruidCallSunlightNatureSpell : ClassSpell
{
    private DruidCallSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCallSunlight);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 34;
    public override int ManaCost => 30;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}