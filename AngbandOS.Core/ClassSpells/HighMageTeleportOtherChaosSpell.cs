[Serializable]
internal class HighMageTeleportOtherChaosSpell : ClassSpell
{
    private HighMageTeleportOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportOther);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 8;
}