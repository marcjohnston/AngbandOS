[Serializable]
internal class HighMageWardingTrueLifeSpell : ClassSpell
{
    private HighMageWardingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellWardingTrue);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 70;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}