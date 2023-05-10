internal class WarriorMageWardingTrueLifeSpell : ClassSpell
{
    private WarriorMageWardingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellWardingTrue);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 70;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}