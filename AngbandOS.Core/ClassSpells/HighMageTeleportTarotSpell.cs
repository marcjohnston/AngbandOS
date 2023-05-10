[Serializable]
internal class HighMageTeleportTarotSpell : ClassSpell
{
    private HighMageTeleportTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleport);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}