internal class WarriorMageElderSignLifeSpell : ClassSpell
{
    private WarriorMageElderSignLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellElderSign);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 70;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 5;
}