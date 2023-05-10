internal class RogueTeleportSorcerySpell : ClassSpell
{
    private RogueTeleportSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleport);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 1;
}