// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Powers;

[Serializable]
internal class SpecialSustainPower : Power
{
    private SpecialSustainPower(SaveGame saveGame) : base(saveGame) { } // This object is a singleton
    public override void Activate(Activation bonusPowerSubType, Item item)
    {
        bonusPowerSubType.ActivateSpecialSustain(item.Characteristics);
    }
}
