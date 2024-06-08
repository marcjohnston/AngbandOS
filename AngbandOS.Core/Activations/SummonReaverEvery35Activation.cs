// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon animals.
/// </summary>
[Serializable]
internal class SummonReaverEvery500p1d500Activation : Activation
{
    private SummonReaverEvery500p1d500Activation(Game game) : base(game) { }
    public override string? PreActivationMessage => "Your {0} flickers black for a moment...";
    
    protected override bool OnActivate(Item item)
    {
        Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterFilter>(nameof(ReaverMonsterFilter)), true);
        return true;
    }

    protected override string RechargeTimeRollExpression => "1d500+500";

    public override int Value => 10000;

    public override string Name => "Summon a black reaver";

}
