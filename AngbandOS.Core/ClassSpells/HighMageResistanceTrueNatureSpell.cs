[Serializable]
internal class HighMageResistanceTrueNatureSpell : ClassSpell
{
    private HighMageResistanceTrueNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistanceTrue);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 15;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 60;
}