[Serializable]
internal class WarriorMageHorrifyDeathSpell : ClassSpell
{
    private WarriorMageHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}