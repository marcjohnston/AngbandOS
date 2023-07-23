// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class ResistanceAmuletJeweleryItem : AmuletJeweleryItem
{
    public ResistanceAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ResistanceAmuletJeweleryItemFactory>()) { }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (SaveGame.Rng.DieRoll(3) == 1)
        {
            IArtifactBias? artifactBias = null;
            ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(34) + 4);
        }
        if (SaveGame.Rng.DieRoll(5) == 1)
        {
            RandartItemCharacteristics.ResPois = true;
        }
    }

}