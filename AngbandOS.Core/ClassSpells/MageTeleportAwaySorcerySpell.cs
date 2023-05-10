internal class MageTeleportAwaySorcerySpell : ClassSpell
{
    private MageTeleportAwaySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleportAway);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 12;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}