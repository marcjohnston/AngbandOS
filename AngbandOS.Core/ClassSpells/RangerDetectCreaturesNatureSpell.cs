[Serializable]
internal class RangerDetectCreaturesNatureSpell : ClassSpell
{
    private RangerDetectCreaturesNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDetectCreatures);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 1;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 2;
}