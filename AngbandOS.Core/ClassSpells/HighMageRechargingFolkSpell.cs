[Serializable]
internal class HighMageRechargingFolkSpell : ClassSpell
{
    private HighMageRechargingFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRecharging);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 22;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 30;
}