[Serializable]
internal class HighMageCallSunlightNatureSpell : ClassSpell
{
    private HighMageCallSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCallSunlight);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 34;
    public override int ManaCost => 30;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}