namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowMonsterWandItem : WandItem
    {
        public SlowMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandSlowMonster>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
        }
    }
}