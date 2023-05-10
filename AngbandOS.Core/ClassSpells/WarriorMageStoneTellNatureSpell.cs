internal class WarriorMageStoneTellNatureSpell : ClassSpell
{
    private WarriorMageStoneTellNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneTell);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 42;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}