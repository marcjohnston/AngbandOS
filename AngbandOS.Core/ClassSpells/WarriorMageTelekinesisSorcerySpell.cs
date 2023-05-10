[Serializable]
internal class WarriorMageTelekinesisSorcerySpell : ClassSpell
{
    private WarriorMageTelekinesisSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTelekinesis);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 19;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 70;
}