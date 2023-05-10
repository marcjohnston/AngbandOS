internal class WarriorMageHeroismLifeSpell : ClassSpell
{
    private WarriorMageHeroismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHeroism);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 40;
}