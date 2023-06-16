// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ClearPotionFlavour : PotionFlavour
{
    private ClearPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override string Name => "Clear";
    /// <summary>
    /// Returns a shuffle weight of 3, so that it appears first.
    /// </summary>
    public override int ShuffleWeight => 3;

    /// <summary>
    /// Returns false because the clear potion flavour is manually assigned to the water potion.
    /// </summary>
    public override bool CanBeAssigned => false;
}
