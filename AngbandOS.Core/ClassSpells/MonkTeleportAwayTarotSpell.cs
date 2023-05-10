internal class MonkTeleportAwayTarotSpell : ClassSpell
{
    private MonkTeleportAwayTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportAway);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 17;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 5;
}