internal class MageBanishLifeSpell : ClassSpell
{
    private MageBanishLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBanish);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 55;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}