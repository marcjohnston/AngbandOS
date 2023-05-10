internal class WarriorMageDarkBoltDeathSpell : ClassSpell
{
    private WarriorMageDarkBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarkBolt);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 18;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 15;
}