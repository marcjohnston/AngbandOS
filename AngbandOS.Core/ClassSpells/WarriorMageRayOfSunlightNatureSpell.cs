[Serializable]
internal class WarriorMageRayOfSunlightNatureSpell : ClassSpell
{
    private WarriorMageRayOfSunlightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellRayOfSunlight);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 14;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}