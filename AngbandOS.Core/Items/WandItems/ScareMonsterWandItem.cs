namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ScareMonsterWandItem : WandItem
    {
        public ScareMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandScareMonster>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        }
    }
}