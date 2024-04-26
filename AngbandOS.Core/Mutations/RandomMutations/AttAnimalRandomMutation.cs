// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class AttAnimalRandomMutation : Mutation
{
    private AttAnimalRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start attracting animals.";
    public override string HaveMessage => "You attract animals.";
    public override string LoseMessage => "You stop attracting animals.";

    public override void OnProcessWorld()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(7000) != 1)
        {
            return;
        }
        bool aSummon;
        if (base.Game.DieRoll(3) == 1)
        {
            aSummon = Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.MonsterFilters.Get(nameof(AnimalMonsterFilter)), true);
        }
        else
        {
            aSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.MonsterFilters.Get(nameof(AnimalMonsterFilter)));
        }
        if (!aSummon)
        {
            return;
        }
        Game.MsgPrint("You have attracted an animal!");
        Game.Disturb(false);
    }
}