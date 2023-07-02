// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavours;

[Serializable]
internal class LightBrownPotionFlavour : PotionFlavour
{
    private LightBrownPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Light Brown";
    /// <summary>
    /// Returns a shuffle weight of 2, so that it appears after the clear potion, but before the light brown potion flavour.
    /// </summary>
    public override int ShuffleWeight => 2;

    /// <summary>
    /// Returns false because the light brown potion flavour is manually assigned to the apple juice potion.
    /// </summary>
    public override bool CanBeAssigned => false;
}
