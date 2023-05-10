internal class WarriorMageDispelEvilLifeSpell : ClassSpell
{
    private WarriorMageDispelEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelEvil);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 38;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 75;
}