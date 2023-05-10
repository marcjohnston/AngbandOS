[Serializable]
internal class HighMageRechargingSorcerySpell : ClassSpell
{
    private HighMageRechargingSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellRecharging);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 9;
}