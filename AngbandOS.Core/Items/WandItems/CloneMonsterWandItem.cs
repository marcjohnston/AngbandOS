namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CloneMonsterWandItem : WandItem
    {
        public CloneMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandCloneMonster>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        }
    }
}