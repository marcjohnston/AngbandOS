// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons
{
    [Serializable]
    internal class PatronUbboSathla : Patron
    {
        private PatronUbboSathla(SaveGame saveGame) : base(saveGame) { }
        public override string ShortName => "Ubbo-Sathla";
        public override string LongName => "Ubbo-Sathla, the Unbegotten Source";
        public override int PreferredAbility => Ability.Charisma;
        protected override Reward[] Rewards => new Reward[]
        {
            SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
            SaveGame.SingletonRepository.Rewards.Get<PissOffReward>(),
            SaveGame.SingletonRepository.Rewards.Get<PissOffReward>(),
            SaveGame.SingletonRepository.Rewards.Get<RuinAblReward>(),
            SaveGame.SingletonRepository.Rewards.Get<LoseAblReward>(),
            SaveGame.SingletonRepository.Rewards.Get<LoseExpReward>(),
            SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
            SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
            SaveGame.SingletonRepository.Rewards.Get<PolyWndReward>(),
            SaveGame.SingletonRepository.Rewards.Get<SerDemoReward>(),
            SaveGame.SingletonRepository.Rewards.Get<PolySlfReward>(),
            SaveGame.SingletonRepository.Rewards.Get<HealFulReward>(),
            SaveGame.SingletonRepository.Rewards.Get<HealFulReward>(),
            SaveGame.SingletonRepository.Rewards.Get<GoodObjReward>(),
            SaveGame.SingletonRepository.Rewards.Get<GainExpReward>(),
            SaveGame.SingletonRepository.Rewards.Get<GainExpReward>(),
            SaveGame.SingletonRepository.Rewards.Get<ChaosWpReward>(),
            SaveGame.SingletonRepository.Rewards.Get<GainAblReward>(),
            SaveGame.SingletonRepository.Rewards.Get<GreaObjReward>(),
            SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>()
        };
    }
}