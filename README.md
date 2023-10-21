# ![The Cat](Cat/Assets/Cat_frame.png) The Cat Game
### Language: C#
### Software: Unity

#### [Play The Game](https://salarkhannn.itch.io/cat-game)

#### Controls:
- W, A, S, D or arrow keys to move
- Space Bar to jump
- Left Shift to Dash
#### Description:
The Cat game is my final project for CS50 Introduction to Computer Science.
This was my first time working in unity and C# so. Even though it was quite challenging I still enjoyed working on this project.

#### Gameplay:
In the Cat Game, your goal is to guide an adorable cat through levels filled with obstacles like water, lava, and spikes to reach the end of each level and collect a fish!

### Scripts:
The Cat Game's engaging mechanics come to life through a series of scripts that form its core gameplay:

StartMenu.cs:
This script enhances the start menu buttons with functionality, making your interaction with the game seamless.

PlayerMovement.cs:\
\
Enable the cat's movement, jumping, and dashing through this script. Experience fluid controls with the help of Unity's Rigidbody system. The script handles the cat's animations based on its movements. The implementation involves modifying the Rigidbody's velocity for running and jumping, offering a smoother and more satisfying player experience. The dash mechanic augments the horizontal velocity while momentarily suspending gravity, ensuring a weightless dash. The "Coyote time" feature extends the window for mid-air jumps, contributing to a fair and enjoyable gameplay. Running animations dynamically adapt to the cat's facing direction.

BetterJump.cs:\
\
Tailored for responsive controls, this script refines jumping mechanics. The cat executes smaller or larger jumps depending on the duration of the jump button press. Additionally, fall time is reduced to provide a snappier feel during gameplay.

RoomTransition.cs:\
\
Improve the camera's orientation with RoomTransition.cs, ensuring a seamless shift as the cat enters new areas within the game.

Sounds.cs:\
\
Elevate the auditory dimension of the game with this script, which defines the properties of sounds through the Sound class.

AudioManager.cs:\
\
Experience an immersive soundscape orchestrated by the AudioManager script. Enjoy background music and well-timed sound effects as you navigate the challenges.

Death.cs:\
\
Dynamically interact with obstacles using the Death script. Upon collision, the script orchestrates level restarts, maintaining the game's flow and challenge.

Additional scripts in the Assets/Scripts Folder enhance the game further.
### Design and Visuals:
The visual assets that breathe life into The Cat Game were sourced from talented artists on itch.io:
- Tileset: [Fanatasy Swamp Forest](https://theflavare.itch.io/forest-nature-fantasy-tileset)
- Cat: (https://bowpixel.itch.io/cat-50-animations)

<img src="https://i.imgur.com/2XwiRpz.gif" width="500"/>

#### Takeaway:
My journey through The Cat Game project enriched my understanding of game development. Witnessing each alteration's immediate impact in a tangible way was highly rewarding.
