internal class PriestCallSunlightNatureSpell : ClassSpell
{
    private PriestCallSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCallSunlight);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 38;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}