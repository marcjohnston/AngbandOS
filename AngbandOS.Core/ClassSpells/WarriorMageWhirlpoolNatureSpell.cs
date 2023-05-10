internal class WarriorMageWhirlpoolNatureSpell : ClassSpell
{
    private WarriorMageWhirlpoolNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlpool);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 38;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 65;
}