[Serializable]
internal class PriestWonderChaosSpell : ClassSpell
{
    private PriestWonderChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWonder);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 7;
}