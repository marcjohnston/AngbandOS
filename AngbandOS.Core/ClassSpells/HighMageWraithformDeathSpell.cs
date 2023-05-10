[Serializable]
internal class HighMageWraithformDeathSpell : ClassSpell
{
    private HighMageWraithformDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWraithform);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 75;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}