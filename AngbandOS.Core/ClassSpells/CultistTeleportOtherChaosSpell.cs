[Serializable]
internal class CultistTeleportOtherChaosSpell : ClassSpell
{
    private CultistTeleportOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportOther);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 8;
}