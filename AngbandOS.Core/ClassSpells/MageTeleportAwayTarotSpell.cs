[Serializable]
internal class MageTeleportAwayTarotSpell : ClassSpell
{
    private MageTeleportAwayTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportAway);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 5;
}