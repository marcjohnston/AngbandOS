[Serializable]
internal class RangerRayOfSunlightNatureSpell : ClassSpell
{
    private RangerRayOfSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellRayOfSunlight);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 9;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 4;
}