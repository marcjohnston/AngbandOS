[Serializable]
internal class PriestDetectCreaturesNatureSpell : ClassSpell
{
    private PriestDetectCreaturesNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDetectCreatures);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}