# AngbandOS
This is the AngbandOS roguelike game. It's a 'classic' roguelike in that it uses ASCII characters rather than graphics.
![image](https://user-images.githubusercontent.com/8724403/216423168-49db9fb6-da17-459d-bb6b-97da14e89654.png)

Developed using ASP.NET 6, it is compatible with Windows, Linux and MAC.  AngbandOS is a heavily refactored forked of Cthangband and broken down into a "core" library that provides all game functionality and separate UI's.  The primary UI is an HTTP interface which is currently available to the public via http://angbandos.skarstech.com.  The original Cthangband fork UI (WPF) is also being maintained.

The goal for AngbandOS is to make the game extensible.  This is being accomplished by refactoring the game into objects.  The pie-in-the-sky goal will be to have an HTTP UI designer that allows players/users to create their own flavor with no development experience/skills needed.

The OS in AngbandOS currently stands for "Open-System".  If the pie-in-the-sky effort is realized, the OS will stand for "Operating-System".

AngbandOS is built using these technologies:
- .NET 6
- EntityFrameWork Core 6
- MySql 5.6
- Angular 13
- Signal-R
- SASS
