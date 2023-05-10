internal class RogueTeleportLevelSorcerySpell : ClassSpell
{
    private RogueTeleportLevelSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleportLevel);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 17;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 30;
}