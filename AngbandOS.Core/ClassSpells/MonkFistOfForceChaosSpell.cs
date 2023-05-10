[Serializable]
internal class MonkFistOfForceChaosSpell : ClassSpell
{
    private MonkFistOfForceChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFistOfForce);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 15;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 6;
}