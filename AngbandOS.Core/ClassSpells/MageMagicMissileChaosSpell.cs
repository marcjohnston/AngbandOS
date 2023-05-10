[Serializable]
internal class MageMagicMissileChaosSpell : ClassSpell
{
    private MageMagicMissileChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMagicMissile);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}