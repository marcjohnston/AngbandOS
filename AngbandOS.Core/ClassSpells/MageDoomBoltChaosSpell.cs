[Serializable]
internal class MageDoomBoltChaosSpell : ClassSpell
{
    private MageDoomBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDoomBolt);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 11;
}