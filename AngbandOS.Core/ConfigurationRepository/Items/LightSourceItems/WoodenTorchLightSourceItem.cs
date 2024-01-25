// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class WoodenTorchLightSourceItem : LightSourceItem
{
    public WoodenTorchLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get(nameof(WoodenTorchLightSourceItemFactory))) { }

    /// <summary>
    /// Returns an intensity of light provided by the torch.  1, if the torch has turns remaining, plus an optional 3
    /// if the torch is an artifact.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public override int CalculateTorch()
    {
        return base.CalculateTorch() + TypeSpecificValue > 0 ? 1 : 0;
    }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (store != null)
        {
            TypeSpecificValue = Constants.FuelTorch / 2;
        }
        else if (TypeSpecificValue != 0)
        {
            TypeSpecificValue = SaveGame.Rng.DieRoll(TypeSpecificValue);
        }
    }
}