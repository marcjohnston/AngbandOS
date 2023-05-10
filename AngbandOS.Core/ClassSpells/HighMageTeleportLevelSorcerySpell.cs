[Serializable]
internal class HighMageTeleportLevelSorcerySpell : ClassSpell
{
    private HighMageTeleportLevelSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleportLevel);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 25;
}