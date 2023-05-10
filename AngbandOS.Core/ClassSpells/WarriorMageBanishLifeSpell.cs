internal class WarriorMageBanishLifeSpell : ClassSpell
{
    private WarriorMageBanishLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBanish);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 55;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}