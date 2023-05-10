internal class WarriorMageSatisfyHungerFolkSpell : ClassSpell
{
    private WarriorMageSatisfyHungerFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSatisfyHunger);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 25;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}