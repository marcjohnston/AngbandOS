[Serializable]
internal class HighMageTelekinesisSorcerySpell : ClassSpell
{
    private HighMageTelekinesisSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTelekinesis);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 70;
}