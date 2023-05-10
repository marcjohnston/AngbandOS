internal class CultistRayOfSunlightNatureSpell : ClassSpell
{
    private CultistRayOfSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellRayOfSunlight);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 14;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}