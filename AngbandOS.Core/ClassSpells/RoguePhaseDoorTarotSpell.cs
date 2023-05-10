[Serializable]
internal class RoguePhaseDoorTarotSpell : ClassSpell
{
    private RoguePhaseDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhaseDoor);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 2;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}