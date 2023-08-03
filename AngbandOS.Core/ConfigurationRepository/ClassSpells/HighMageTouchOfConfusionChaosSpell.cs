// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class HighMageTouchOfConfusionChaosSpell : ClassSpell
{
    private HighMageTouchOfConfusionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTouchOfConfusion);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 2;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 1;
}