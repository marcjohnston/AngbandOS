﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class OldSlowPlayerEffect : PlayerEffectUniversalScript
{
    private OldSlowPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something slow!";
    public override IdentifiedResultEnum Apply(Monster mPtr, int dam)
    {
        Game.SlowTimer.AddTimer(Game.RandomLessThan(4) + 4);
        return IdentifiedResultEnum.True;
    }
}
