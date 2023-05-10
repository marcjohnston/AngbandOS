[Serializable]
internal class HighMageEsoteriaDeathSpell : ClassSpell
{
    private HighMageEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 35;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}