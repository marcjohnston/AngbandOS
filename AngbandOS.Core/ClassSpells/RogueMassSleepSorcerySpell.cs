internal class RogueMassSleepSorcerySpell : ClassSpell
{
    private RogueMassSleepSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellMassSleep);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 4;
}