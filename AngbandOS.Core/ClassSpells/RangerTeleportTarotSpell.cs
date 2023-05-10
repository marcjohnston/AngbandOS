internal class RangerTeleportTarotSpell : ClassSpell
{
    private RangerTeleportTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleport);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}