[Serializable]
internal class PaladinWraithformDeathSpell : ClassSpell
{
    private PaladinWraithformDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWraithform);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 111;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}