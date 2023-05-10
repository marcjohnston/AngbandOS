internal class MagePhaseDoorTarotSpell : ClassSpell
{
    private MagePhaseDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhaseDoor);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}