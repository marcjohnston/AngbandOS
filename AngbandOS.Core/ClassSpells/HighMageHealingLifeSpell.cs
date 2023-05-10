[Serializable]
internal class HighMageHealingLifeSpell : ClassSpell
{
    private HighMageHealingLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealing);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 5;
}