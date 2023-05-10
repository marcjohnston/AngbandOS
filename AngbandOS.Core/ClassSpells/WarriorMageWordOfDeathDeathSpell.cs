internal class WarriorMageWordOfDeathDeathSpell : ClassSpell
{
    private WarriorMageWordOfDeathDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWordOfDeath);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 50;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}