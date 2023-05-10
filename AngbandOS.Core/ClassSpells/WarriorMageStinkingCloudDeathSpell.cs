internal class WarriorMageStinkingCloudDeathSpell : ClassSpell
{
    private WarriorMageStinkingCloudDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellStinkingCloud);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 27;
    public override int FirstCastExperience => 3;
}