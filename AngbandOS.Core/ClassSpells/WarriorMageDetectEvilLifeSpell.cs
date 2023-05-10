internal class WarriorMageDetectEvilLifeSpell : ClassSpell
{
    private WarriorMageDetectEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectEvil);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}