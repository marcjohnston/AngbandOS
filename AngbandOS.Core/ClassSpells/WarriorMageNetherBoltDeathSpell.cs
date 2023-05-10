internal class WarriorMageNetherBoltDeathSpell : ClassSpell
{
    private WarriorMageNetherBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellNetherBolt);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}