[Serializable]
internal class PriestMagicMissileChaosSpell : ClassSpell
{
    private PriestMagicMissileChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMagicMissile);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 22;
    public override int FirstCastExperience => 4;
}