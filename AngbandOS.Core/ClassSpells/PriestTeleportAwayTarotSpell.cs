internal class PriestTeleportAwayTarotSpell : ClassSpell
{
    private PriestTeleportAwayTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportAway);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 17;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 5;
}