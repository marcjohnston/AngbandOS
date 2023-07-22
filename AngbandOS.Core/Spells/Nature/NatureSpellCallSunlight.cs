// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellCallSunlight : Spell
{
    private NatureSpellCallSunlight(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<LightProjectile>(), 0, 150, 8);
        SaveGame.Level.WizLight();
        if (!SaveGame.Race.IsBurnedBySunlight || SaveGame.HasLightResistance)
        {
            return;
        }
        SaveGame.MsgPrint("The sunlight scorches your flesh!");
        SaveGame.TakeHit(50, "sunlight");
    }

    public override string Name => "Whirlpool";
    
    protected override string? Info()
    {
        return "dam 150";
    }
}