internal class CultistCallSunlightNatureSpell : ClassSpell
{
    private CultistCallSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCallSunlight);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 41;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}