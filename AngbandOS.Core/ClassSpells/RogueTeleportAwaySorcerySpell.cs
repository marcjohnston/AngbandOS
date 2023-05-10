internal class RogueTeleportAwaySorcerySpell : ClassSpell
{
    private RogueTeleportAwaySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleportAway);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 23;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 5;
}