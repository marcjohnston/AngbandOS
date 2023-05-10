internal class WarriorMageBatsSenseCorporealSpell : ClassSpell
{
    private WarriorMageBatsSenseCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBatsSense);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}