# Unity3D_SampleProject
Unity 3D Sample Project for C# and Unity 3D for Game Development ISP offered at New College of Florida 

## Unity Version: 2023.2.1f1

## Features
Walled in area -> 
- The main scene is a simple walled in area that has three interactable game objects and a small platform area.

### Player camera/movement ->
- The player moves using WASD and has a first person camera. The code for both the camera and movement is based off the tutorial and textbook below, with modifications.
  - (Tutorial)[https://www.youtube.com/watch?v=f473C43s8nE]
  - Textbook: Learning C# by Developing Games with Unity Seventh Edition by Harrison Ferrone
- The player is a simple capsule shape and moves at a fixed speed.

### 3 Game Objects and Collision and Health Increasing/Decreasing ->
- There are three game objects that can be interacted with. There is a nice cat and a mean cat, both on the lower level. There is also a fat cat, which sits on the platform that the player can move up to. Each cat has a cooldown between each interaction.
- Nice Cat
  - When the nice cat is interacted with, it will increase the player's reputation (health) by a random amount between 0 and a max reputation effect.
- Mean Cat
  - When the mean cat is interacted with, it will decrease the player's reputation (health) by a random amount between 0 and a max reputation effect.
- Fat Cat
  - When the fat cat is interacted with, it will decrease the player's reputation by a specified max reputation effect, and also perform a short spin.
 
### Sound ->
- Each cat will play a sound effect when interacted with. The nice cat will meow, meanwhile the mean and fat cats will hiss.

## Assets
These are the assets used in the project.
Cats
- Fat: https://free3d.com/3d-model/pallas-cat-v1--576987.html
- Ginger: https://free3d.com/3d-model/cat-v1--522281.html 
- Black: https://free3d.com/3d-model/cat-v1--326682.html 
Sound Effects
- https://pixabay.com/sound-effects/search/angry-cats/ 
- https://pixabay.com/sound-effects/search/cat/ 
