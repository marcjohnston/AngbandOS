// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Flavours;

[Serializable]
internal class TanMushroomFlavour : MushroomFlavour
{
    private TanMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Tan";
}