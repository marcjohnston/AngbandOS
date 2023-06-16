// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavours;

[Serializable]
internal abstract class PotionFlavour : Flavour, IWeightedShuffle
{
    protected PotionFlavour(SaveGame saveGame) : base(saveGame)
    {
    }

    /// <summary>
    /// Returns the shuffle weight for the potion flavour.  Potion flavours of a higher weight will appear before potion flavours of a lower weight.  Returns 0, by default.  The default
    /// value will be overriden by the Clear, IckyGreen and LightBrown flavours.
    /// </summary>
    public virtual int ShuffleWeight => 0;
}
