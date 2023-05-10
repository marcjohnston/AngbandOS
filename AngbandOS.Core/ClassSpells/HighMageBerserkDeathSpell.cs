[Serializable]
internal class HighMageBerserkDeathSpell : ClassSpell
{
    private HighMageBerserkDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBerserk);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 15;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 180;
}