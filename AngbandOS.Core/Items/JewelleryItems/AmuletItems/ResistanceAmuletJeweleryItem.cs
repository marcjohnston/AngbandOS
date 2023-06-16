namespace AngbandOS.Core.Items;

[Serializable]
internal class ResistanceAmuletJeweleryItem : AmuletJeweleryItem
{
    public ResistanceAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ResistanceAmuletJeweleryItemFactory>()) { }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (Program.Rng.DieRoll(3) == 1)
        {
            IArtifactBias? artifactBias = null;
            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
        }
        if (Program.Rng.DieRoll(5) == 1)
        {
            RandartItemCharacteristics.ResPois = true;
        }
    }

}