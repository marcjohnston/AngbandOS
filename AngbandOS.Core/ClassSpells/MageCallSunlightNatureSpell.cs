[Serializable]
internal class MageCallSunlightNatureSpell : ClassSpell
{
    private MageCallSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCallSunlight);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 35;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}