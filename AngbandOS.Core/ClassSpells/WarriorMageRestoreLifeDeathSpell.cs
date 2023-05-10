internal class WarriorMageRestoreLifeDeathSpell : ClassSpell
{
    private WarriorMageRestoreLifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRestoreLife);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 55;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 150;
}