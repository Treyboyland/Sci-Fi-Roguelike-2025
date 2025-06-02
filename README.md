# Sci-Fi-Roguelike-2025
A sci-fi twin-stick shooter bullet hell with roguelike progression. You play as a prisoner, on an alien planet, sentenced to an eternity of gladiatorial combat for the entertainment of the galactic emporer and his subjects. If you die they simply clone you, with all your painful memories intact, so you can continue fighting in the arena. But sometimes the cloning isn't perfect and genetic mutations can occur, some of which can give you an edge in battle. Freedom is possible though if you gain enough fame by impressing and entertaining the crowd/emporer enough. Finally the crowd can provide random weapons or upgrades after each round, but you must have enough fame to purchase them.

## Action Mechanics
### Moving & Combat
	1. Standard top down movement
		1. On keyboard use WASD and arrow keys to move
		2. On gamepad use D-Pad and left joystick
		3. Make sure on gamepad that movement follows exact angle of the joystick
		4. Have slight accel/decel: ~100-150ms to accelerate to max, ~200-300ms to decelerate to stop
	2. Standard aiming
		1. On mouse/keyboard use angle towards mouse cursor
		2. On gamepad use right joystick angle
		3. Hide default mouse cursor and use custom sprite reticle
	3. Camera
		1. Cinemachine (specifically with position composer) handles all of this for us, we just have configure it
		2. Camera will follow the player with slight damping
		3. Set target offset as ~10-20% towards the reticle to slightly bias the camera towards where player is aiming
		4. Slight deadzone ~5-15% to reduce constant camera movement
		5. Slight look ahead so camera biases towards direction of movement
		6. None of the above values will be perfect at first but can be constantly tweaked until we like it
		7. Camera shake on shooting, player being hit, and other impactful events
		8. Hit-stops on player taking big damage, defeating an enemy, and other impactful events
### Obstacles & Traps
### Enemies

## Progression
### Game Loop
### Round Goals & Rewards
### Genetic Mutations
### Achievements & Unlocks

## UI
### HUD
### Menus

## Save Data
### Player preferences
### Progression
