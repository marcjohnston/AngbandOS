// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Borg;

internal static class borg_cfg
{
    //# This file will allow you to customize your APWBorg along certain themes.
    //# The borg is fairly successful, having won the game several times.
    //# However, some players/observers of borgs would like to see it function
    //# differently.  Some would like to see the borg play more aggressively, or
    //# more conservatively.  While others would like to value armour class more.
    //# Still others would like to see it collect more speed items.

    //# With the expressions below, you can influence the borg's behavior and
    //# equipment selection choices.  The 'borg_worship_' variables will influence
    //# his equipment selection by adding additional bonuses to items which
    //# enhance that attribute.  For example:  if a borg recieves 2000 pts for
    //# a single point of armour class, an 'ac worshipping' borg would receive
    //# 3000 pts.  This bonus would significantly influence equipment choices.

    //# borg_worships_gold explained:
    //# The borg_worships_gold option will greatly impact how the borg treats items
    //# which he finds in the dungeon.  With this opion on, he will return to town
    //# whenever he fills up with items then sell those items.  This can cause
    //# the borg to lose some artifacts, since he will sell them even if not ID'd.
    //# Generally speaking the borg will not sell an item unless it is at least
    //# psuedo ID'd.  The benefit of this option is that the borg will significantly
    //# increase his income at the low clevels.  This will increase his survivablity
    //# by allowing him to invest in armour and arrows.  With this on,
    //# he will not recall to town to sell stuff but climb the stairs instead.
    //# He will also not recall into the dungeon until dlevel 8 (instead of 5).
    //# This option has no effect after clevel 20.  One other downside of this is
    //# that the borg will spend more time in town and may have to evade Vets more.

    //# To modify, simply set it to TRUE or FALSE.

    //# Worships

    public static bool borg_worships_damage = false;
    public static bool borg_worships_speed = false;
    public static bool borg_worships_hp= false;
    public static bool borg_worships_mana = false;
    public static bool borg_worships_ac = false;
    public static bool borg_worships_gold = false;

    //# use the POWER_ and REQ_ lines below.  If false the borg will
    //# use the calcs in the C code.  Which is recommended since I hone those
    //# more frequently than I do the dynamic calcs.  Most borg users will 
    //# have more successful borgs by leaving this option as FALSE.
    //# note: the dynamic calcs are slower than the internal calcs

    public static bool borg_uses_dynamic_calcs = false;

    //# Risky

    //# A risky borg is one who is not confined by character level requirements
    //# in order to dive deeper.  It is also more likely to stay in a battle than
    //# to teleport out.  A risky borg will dive faster but is more likely to die.
    //# A risky borg is not concerned with killing uniques before diving deeper.
    //#
    //# A borg who scums for uniques will set the auto_scum flag in order to generate
    //# more exciting levels and hopefully encounter a unique
    //# 
    //# borgs who kill_uniques will wait for uniques to die before diving deeper
    //# into the dungeon.  Usually, he will not dive deeper then three uniques.  
    //# Example, Unique Monsters who normally reside on levels 12, 15, and 18 are 
    //# still alive so the borg will not dive deeper than level 18 until at least one
    //# of those uniques are dead.  Setting this to FALSE will allow the borg to dive
    //# deeper, faster, not being held up by the uniques.  But, he does run the risk
    //# of finding 3 or 4 uniques on one level.  That can be a bit scary.

    public static bool borg_plays_risky = false;
    public static bool borg_kills_uniques = false;

    //# Swap Items

    //# The borg is designed to use Swap Items in the inventory.  A swap item
    //# is an equipment item (like a sword or armour item) which posseses a
    //# desireable resistance or trait.  If the borg is in danger, then he will
    //# consider exchanging his current item for the swap item.  A prime example of
    //# this is at dungeon level 60.  He is required to have several resists in
    //# place.  If he does not have them then he will not dive deeper.  However,
    //# with Swaps enabled he will select an item to cover the open resist then
    //# dive down.  Having Swaps enabled allows the borg to dive deeper, faster.
    //# The draw back is the Swap Items take up two inventory slots.

    public static bool borg_uses_swaps = true;

    //# Home Storage

    //# The borg has two routines to store items in the home.  One is very
    //# effective and will make the best possible choice for adding an item to the
    //# home.  Unfortunately, this function is very slow.  A much faster routine
    //# will do a fine job at storing items in the home but it is not as
    //# efficient.

    public static bool borg_slow_optimizehome = false;

    //# Respawn

    //# If the borg is in continual play mode (as with the screen saver),
    //# he will respawn a randomly generated character at death.  This section
    //# allows the user to make certain bias for the type of character generated.
    //# You may select the race and or class and or minimal stats for the Borg.
    //# You may also select the minimal character level needed before the
    //# character dump is created in the game directory.

    //# With regards to race, the borg is programmed to accept the variety of
    //# user defined races which may be in the p_info.txt file.  So the values
    //# given in table below are for the default races.  But if you are bright
    //# enough to modify the p_info.txt file then you are bright enough to figure
    //# out that race 0 does not necessarily equal Human.  It's just the first
    //# race listed in your p_info.txt file.
    //#
    //# RACE:-1 Random Race          CLASS:  -1 Random Class
    //#       0 Human                         0 Warrior
    //#       1 Half Elf                      1 Mage
    //#       2 Elf                           2 Druid
    //#       3 Hobbit                        3 Priest
    //#       4 Gnome                         4 Necromancer
    //#       5 Dwarf                         5 Paladin
    //#       6 Half Orc                      6 Rogue
    //#       7 Half Troll                    7 Ranger
    //#       8 Dunadan                       8 Blackguard
    //#       9 High Elf
    //#	   10 Kobold
    //#
    //# With regards to the stats.  The minimal stats are rolled by the
    //# borg.  CON will be 16, the secondary stat (usually DEX) will be 17,
    //# The primary stat will be 17.  These are the maximal values which
    //# can be rolled (racial and class bonuses added after).
    //# If the borg can not reach the stats after 500,000 tries the game
    //# will just assign you a random stat.
    //#
    //# After killing Morgoth, generally, the borg will stop and allow you
    //# to inspect the victory.  If you set the respawn_winners then after
    //# killing Morgoth,the borg will generate a new character.  A map file
    //# is created so you can see what the final battle looked like.

    public static int borg_respawn_race = -1;
    public static int borg_respawn_class = -1;
    public static bool borg_respawn_winners = false;


    //# Dumps

    //# This variable will determine the minimal character level at which the borg
    //# will create a character dump file.  That file contains some vital information
    //# concerning the status of the borg at the time of his demise.  It is placed
    //# in the user directory.
    //# The borg_save_death variable will tell the borg to save the game in the user
    //# directory so that it can be examined more closely.  The clevel of the borg
    //# must at least equal the borg_dump_level in order for the game to save.

    public static int borg_dump_level = 1;
    public static int borg_save_death = 1;

    //# Auto Stops

    //# The borg is able to stop when it reaches a certain dungeon depth or character
    //# level.  He will also stop when he wins the game.  If you want him to keep
    //# playing, even after Morgoth is dead, then change the borg_stop_king to FALSE.
    //# Set the other values to the level at which you want the borg to stop.  Set
    //# them out of bounds if you do not want him to stop.

    public static int borg_stop_dlevel = 128;
    public static int borg_stop_clevel = 51;
    public static int borg_no_deeper = 127;
    public static bool borg_stop_king = true;

    //# Chest Tolerance

    //# The borg is able to search, disarm, and open chests.  There is a inherant
    //# risk when dealing with chests.  The risk of setting off the trap vs the
    //# benefit of the loot within the chest.  The game uses a straight forward 
    //# formula for calculating the success of a chest.  It is:
    //# randint(100) < the skill of the player minus the dificulty of the chest.
    //# Difficulties run from 1 to 63.  I would recommend a tolerance of about 7
    //# for vanilla chests (since they suck) and about 15 for DrAngband.

    public static int borg_chest_fail_tolerance = 7;

    //# Speed of the Borg

    //# You can slow the borg down several different ways.  One way is to set the
    //# base game delay factor in the options menu.  This will slow down the borg
    //# and the visual effects (like missiles shooting, explosions).  If using the
    //# screensaver, you will need to load angband.exe load the savefile, make the
    //# modifications, then save and exit.  Another way to slow the borg down is
    //# to add more term windows.  The more it has to do, the slower it will be.
    //# I recommend using Inventory, Equipment, Messages, Monster Recall, Borg
    //# Status windows. Then you can really see what the borg is up to.  Lastly,
    //# to slow the borg down use the following variable.  The formula is:
    //# base_game_delay_factor^2 + borg_delay_factor^2.

    public static int BORG_DELAY_FACTOR = 0;

}
