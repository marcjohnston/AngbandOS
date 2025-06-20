﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Talents;

[Serializable]
internal class TelekineticWaveTalent : Talent
{
    private TelekineticWaveTalent(Game game) : base(game) { }
    public override string Name => "Telekinetic Wave";
    public override int Level => 28;
    public override int ManaCost => 20;
    public override int BaseFailure => 45;

    public override void Use()
    {
        Game.MsgPrint("A wave of pure physical force radiates out from your body!");
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(TelekinesisProjectile));
        projectile.Fire(0, 3 + (Game.ExperienceLevel.IntValue / 10), Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue * (Game.ExperienceLevel.IntValue > 39 ? 4 : 3), item: true, kill: true, grid: true, jump: false, beam: false, thru: false, hide: false, stop: false);
    }

    protected override string LearnedDetails()
    {
        return $"dam {Game.ExperienceLevel.IntValue * (Game.ExperienceLevel.IntValue > 39 ? 4 : 3)}";
    }
}