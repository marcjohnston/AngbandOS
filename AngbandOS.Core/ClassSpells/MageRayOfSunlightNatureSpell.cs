[Serializable]
internal class MageRayOfSunlightNatureSpell : ClassSpell
{
    private MageRayOfSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellRayOfSunlight);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 6;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 6;
}