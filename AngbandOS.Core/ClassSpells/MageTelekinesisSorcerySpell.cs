[Serializable]
internal class MageTelekinesisSorcerySpell : ClassSpell
{
    private MageTelekinesisSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTelekinesis);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 70;
}