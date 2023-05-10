[Serializable]
internal class HighMageBanishLifeSpell : ClassSpell
{
    private HighMageBanishLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBanish);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 44;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 115;
}