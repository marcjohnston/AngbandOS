// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon phantom warriors or beasts.
/// </summary>
[Serializable]
internal class SummonPhantomActivation : Activation
{
    private SummonPhantomActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "You summon a phantasmal servant.";

    protected override bool OnActivate(Item item)
    {
        Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterFilter>(nameof(PhantomMonsterFilter)), true);
        return true;
    }

    public override int RechargeTime() => 200 + Game.DieRoll(200);

    public override int Value => 12000;

    public override string Name => "Summon phantasmal servant";

    public override string Frequency => "200+d200";
}
