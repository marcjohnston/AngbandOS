[Serializable]
internal class FanaticTeleportOtherChaosSpell : ClassSpell
{
    private FanaticTeleportOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportOther);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 24;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}