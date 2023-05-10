internal class WarriorMageStoneSkinNatureSpell : ClassSpell
{
    private WarriorMageStoneSkinNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneSkin);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 120;
}