[Serializable]
internal class HighMageResistPoisonDeathSpell : ClassSpell
{
    private HighMageResistPoisonDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellResistPoison);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 9;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 6;
}