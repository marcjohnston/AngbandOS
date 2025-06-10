// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Security.Cryptography.X509Certificates;
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class HornsRandomMutation : Mutation
{
    private HornsRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "Horns pop forth into your forehead!";
    public override string HaveMessage => "You have horns (dam. 2d6).";
    public override string LoseMessage => "Your horns vanish from your forehead!";
    public override int DamageDiceSize => 2;
    public override int DamageDiceNumber => 6;
    public override int EquivalentWeaponWeight => 15;
    public override string AttackDescription => "horns";

    public override void OnGain()
    {
        Game.NaturalAttacks.Add(this);
    }

    public override void OnLose()
    {
        Game.NaturalAttacks.Remove(this);
    }
}