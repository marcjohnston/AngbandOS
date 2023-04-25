namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistanceAmuletItem : AmuletItem
    {
        public ResistanceAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletResistance>()) { }

        public override void ApplyMagic(int level, int power)
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
}