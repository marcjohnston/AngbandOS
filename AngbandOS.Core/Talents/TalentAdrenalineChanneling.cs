// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class TalentAdrenalineChanneling : Talent
{
    public override string Name => "Adrenaline Channeling";
    public override void Initialise(int characterClass)
    {
        Level = 23;
        ManaCost = 15;
        BaseFailure = 50;
    }

    public override void Use(SaveGame saveGame)
    {
        saveGame.Player.TimedFear.ResetTimer();
        saveGame.Player.TimedStun.ResetTimer();
        saveGame.Player.RestoreHealth(saveGame.Player.Level);
        int i = 10 + Program.Rng.DieRoll(saveGame.Player.Level * 3 / 2);
        if (saveGame.Player.Level < 35)
        {
            saveGame.Player.TimedHeroism.AddTimer(i);
        }
        else
        {
            saveGame.Player.TimedSuperheroism.AddTimer(i);
        }
        if (saveGame.Player.TimedHaste.TurnsRemaining == 0)
        {
            saveGame.Player.TimedHaste.SetTimer(i);
        }
        else
        {
            saveGame.Player.TimedHaste.AddTimer(i);
        }
    }

    protected override string Comment(Player player)
    {
        return $"dur 10+d{player.Level * 3 / 2}";
    }
}