internal class CultistMagicMissileChaosSpell : ClassSpell
{
    private CultistMagicMissileChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMagicMissile);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 4;
}