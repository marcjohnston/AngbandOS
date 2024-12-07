// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class BeakRandomMutation : Mutation
{
    private BeakRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "Your mouth turns into a sharp, powerful beak!";
    public override string HaveMessage => "You have a beak (dam. 2d4).";
    public override string LoseMessage => "Your mouth reverts to normal!";
    public override MutationGroupEnum Group => MutationGroupEnum.Mouth;
    public override int DamageDiceSize => 2;
    public override int DamageDiceNumber => 4;
    public override int EquivalentWeaponWeight => 5;
    public override string AttackDescription => "beak";

    public override void OnGain()
    {
        Game.NaturalAttacks.Add(this);
    }

    public override void OnLose()
    {
        Game.NaturalAttacks.Remove(this);
    }
}