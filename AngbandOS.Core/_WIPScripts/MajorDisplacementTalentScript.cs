// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MajorDisplacementTalentScript : UniversalScript, IGetKey
{
    private MajorDisplacementTalentScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState) { }
    public override void ExecuteScript()
    {
        Game.RunScript(nameof(TeleportSelf5xTeleportSelfScript));
        if (Game.ExperienceLevel.IntValue > 29)
        {
            Game.RunScript(nameof(TeleportAwayAllAtLos1xProjectileScript));
        }
    }
}
