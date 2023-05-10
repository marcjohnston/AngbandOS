internal class RogueTelekinesisSorcerySpell : ClassSpell
{
    private RogueTelekinesisSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTelekinesis);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 50;
}