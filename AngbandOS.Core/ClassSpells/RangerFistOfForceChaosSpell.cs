[Serializable]
internal class RangerFistOfForceChaosSpell : ClassSpell
{
    private RangerFistOfForceChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFistOfForce);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 21;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 3;
}