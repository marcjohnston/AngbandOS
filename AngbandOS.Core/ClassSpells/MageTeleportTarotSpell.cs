internal class MageTeleportTarotSpell : ClassSpell
{
    private MageTeleportTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleport);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}