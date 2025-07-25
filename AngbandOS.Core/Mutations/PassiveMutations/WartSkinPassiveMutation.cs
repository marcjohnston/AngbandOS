﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class WartSkinPassiveMutation : Mutation
{
    private WartSkinPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "Disgusting warts appear everywhere on you!";
    public override string HaveMessage => "Your skin is covered with warts (-2 CHR, +5 AC).";
    public override string LoseMessage => "Your warts disappear!";
    public override MutationGroupEnum Group => MutationGroupEnum.Skin;

    public override void OnGain()
    {
        Game.CharismaBonus -= 2;
        Game.GenomeArmorClassBonus += 5;
    }

    public override void OnLose()
    {
        Game.CharismaBonus += 2;
        Game.GenomeArmorClassBonus -= 5;
    }
}