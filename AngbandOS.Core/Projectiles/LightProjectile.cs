// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class LightProjectile : Projectile
{
    private LightProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BrightWhiteBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightWhiteCloudAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        cPtr.SelfLit = true;
        Game.NoteSpot(y, x);
        Game.MainForm.RefreshMapLocation(y, x);
        if (Game.PlayerCanSeeBold(y, x))
        {
            obvious = true;
        }
        if (cPtr.MonsterIndex != 0)
        {
            Game.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
        }
        return obvious;
    }

    protected override string AffectMonsterScriptBindingKey => nameof(LightAffectMonsterScript);

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by something!");
        }
        if (Game.HasLightResistance)
        {
            dam *= 4;
            dam /= Game.DieRoll(6) + 6;
        }
        else if (!blind && !Game.HasBlindnessResistance)
        {
            Game.BlindnessTimer.AddTimer(Game.DieRoll(5) + 2);
        }
        if (Game.Race.IsBurnedBySunlight)
        {
            Game.MsgPrint("The light scorches your flesh!");
            dam *= 2;
        }
        Game.TakeHit(dam, killer);
        if (Game.EtherealnessTimer.Value != 0)
        {
            Game.EtherealnessTimer.SetValue();
            Game.MsgPrint("The light forces you out of your incorporeal shadow form.");
            Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        return true;
    }
}