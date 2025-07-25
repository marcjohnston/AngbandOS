﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class IronSkinPassiveMutation : Mutation
{
    private IronSkinPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "Your skin turns to steel!";
    public override string HaveMessage => "Your skin is made of steel (-1 DEX, +25 AC).";
    public override string LoseMessage => "Your skin reverts to flesh!";
    public override MutationGroupEnum Group => MutationGroupEnum.Skin;

    public override void OnGain()
    {
        Game.DexterityBonus -= 1;
        Game.GenomeArmorClassBonus += 25;
    }

    public override void OnLose()
    {
        Game.DexterityBonus += 1;
        Game.GenomeArmorClassBonus -= 25;
    }
}