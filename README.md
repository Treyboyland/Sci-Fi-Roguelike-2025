# Sci-Fi-Roguelike-2025
A sci-fi twin-stick shooter bullet hell with roguelike progression. You play as a prisoner, on an alien planet, sentenced to an eternity of gladiatorial combat for the entertainment of the galactic emporer and his subjects. If you die they simply clone you, with all your painful memories intact, so you can continue fighting in the arena. But sometimes the cloning isn't perfect and genetic mutations can occur, some of which can give you an edge in battle. Freedom is possible though if you gain enough fame by impressing and entertaining the crowd/emporer enough. Finally the crowd can provide random weapons or upgrades after each round, but you must have enough fame to purchase them.

## Action Mechanics
### Moving & Combat
	1. Standard top down movement
		1. On keyboard use WASD and arrow keys to move
		2. On gamepad use D-Pad and left joystick
		3. Make sure on gamepad that movement follows exact angle of the joystick
		4. Have slight accel/decel: ~100-150ms to accelerate to max, ~200-300ms to decelerate to stop
		5. Player will face to the right by default, and if moving to the left (between 90 and 270 degrees) then the sprite will flip along X (I think)
		6. Up and down movement will not alter the sprite
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
	4. Shooting & Guns
		1. Gun location will set to an empty child object on player (so we can design a good position to set it to)
		2. Guns will have their own child game object that acts as a muzzle location (so bullets spawn in the correct place)
		3. Guns will rotate towards the reticle with the barrel pointing exactly at it
		4. Guns will all point to the right (zero degrees) by default, and if angle is between 90 and 270 then gun sprite will be flipped along X (I think)
		5. On mouse/keyboard use LMB to shoot and R to reload
		6. On gamepad use RT to shoot and X to reload
		7. Holding down the button will repeat the action when possible (no need to re-press for every shot)
		8. Gun stats (most of this will apply to enemy shooting also)
			1. Bullet damage
			2. Number of bullets
			3. Is burst (do all bullets shoot at once or one at a time? only applies if numBullets > 1)
			4. Burst timing (only applies if isBurst=true, amount of time between each bullet)
			5. Bullet spread (angle, only applies if numBullets > 1)
			6. Bullet speed
			7. Cooldown between shots
			8. Ammo amount (number of shots before needing a reload)
			9. Reload speed (number of seconds it takes to reload)
			10. Pierce count (zero means no piercing, 2 means bullet can pierce through 2 enemies but stops on hitting 3rd)
			11. Additional critical hit chance (adds to player's base critical hit chance)
			12. Additional stun chance (adds to player's base stun chance)
			13. Additional slow % (adds to player's base slow %)
			14. Random x/y amount
			15. Random angle amount
			16. Random bullet speed amount
	5. Melee Weapons
		1. Weapons will have a location set to player just like guns
		2. Weapons will also rotate towards the reticle just like guns
		3. Weapons will also all point to the right by default and sprite flip the same as guns
		4. Same button controls as guns except no reloading
		5. When player attacks the weapon will thrust towards the reticle and quickly come back
		6. Weapon stats
			1. Weapon damage
			2. Thrust speed
			3. Thrust distance
			4. Thrust stay time (how long the weapon stays out once it hits the thrust distance, before coming back to player)
			5. Cooldown between thrusts
			6. Hits continually? (if no then does single hit on collision, if yes then hits continually while enemy is overlapping weapon collider)
			7. Continual hit tick time (only applies if hitsContinually=true, the timing between hits while overlapping, because it shouldn't hit every frame - so alternate the collider on/on when the timer expires)
			8. Additional critical hit chance (adds to player's base critical hit chance)
			9. Additional stun chance (adds to player's base stun chance)
			10. Additional slow % (adds to player's base slow %)
	6. Player Combat Stats
		1. Max hp/current hp
		2. Max move speed
		3. Shield
		4. Chance to evade
		5. Plus all damage
		6. Plus gun damage
		7. Plus melee damage
		8. Plus gun bullets
		9. Plus attack speed
		10. Plus pierce
		11. Damage reduction
		12. Critical strike chance
		13. Stun chance
		14. Slow % on hit
		15. Plus fame
		16. Rerolls
		17. Plus items in shop
		18. Cheaper shop items
		
### Obstacles & Traps
	1. Spikes that periodically appear from ground
	2. Spikes on the outer walls of arena
	3. Turrets that shoot bullets at you
	4. Not all of these will appear every round, but can be used as tools when designing
### Enemies
	1. Enemy types: shooters, dashers, exploders
	2. Shooters will stand back and shoot bullets at you and occasionally move to a new location
		1. Will have a lot of the same stats as guns do
		2. But won't worry about ammo/reloading nor piercing
		3. Can probably re-use functionality between guns and enemies
	3. Dashers will run at you very quickly
	4. Exploders will blow up on death
	5. Enemy stats
		1. Max hp/current hp
		2. Max move speed
		3. Damage reduction
		4. Slow % on hit (player will only be slowed for a short time)

## Progression
### Game Loop
	1. Defeat all enemies in a wave
	2. 3 waves to each round
	3. A run consists of 20 rounds
	4. After each round gain fame based on your performance
	5. Pay fame for new weapons and/or items, and upgrades in between each round
	6. If you beat all 20 rounds... good job pat yourself on the back
### Round Goals & Rewards
	1. The goal is to defeat all enemies in a wave, then keep doing that for all rounds
	2. each round has a standard fame amount you gain for beating the round, but if you take a threshold of damage you lose half the fame
	3. each round has a target time to complete - if you beat it under that time you get 50% more fame
### Genetic Mutations
	1. Before a run begins you can pick a genetic mutation
	2. They enhance your character in some fashion and can help create synergies in a build
	3. You have to unlock them by doing achievements
### Achievements & Unlocks
	1. When you accomplish an achievement you unlock some content
	2. You can unlock guns/items/upgrades/genetic mutations that can show up during a run
	3. Some require saving progress between runs such as "defeat 500 aliens"
	4. Others can be one off by doing something hard such as "don't get hit during a round", or "defeat 5 enemies within 2 seconds"

## UI
### HUD
	1. Show HP and shield
	2. Show which round/wave player is on
	3. Show current amount of fame (maybe only shows in-between rounds)
	4. Show extra fame goals - how much damage to be under and target time to complete
	5. Show which gun/weapon is equipped and ammo if applicable
	6. Show reload time/bar during a reload
### Menus
	1. In-game pause menu
		1. Return to game, achievement progress, audio/video options, exit run
		2. Show player stats, gun/weapon stats, items chosen, and current amount of fame
	2. Results menu
		1. No matter if player wins or loses show results
		2. Total fame gained, which round they made it to, number of minutes the run was, number of enemies defeated, what acheivements they unlocked during the run, etc
		3. Two options - Go back to title screen and immediatley start new run
	3. Title screen
		1. Start New
		2. Continue (greyed out on first play)
		3. Audio/video options
		4. Achievement progress
		5. Exit game (desktop build only)
	4. Debouncing - Making sure there's a "isUITransitioning" bool when moving to/from/between UI menus
### Transitions
	1. Need a way to visually transition from title screen to a run, and a from a run to results screen, etc
	2. Easiest way is no transition, just a jump cut, but that can be jarring
	3. If we want something less jarring but still simple then a fade works - when a scene ends fade in a solid color texture over the screen, when a new scene starts then fade that texture back out (we can think of something more fancy if we want)
	4. Debouncing - Make sure there's a "isSceneTransitioning" bool during that time so certain actions can't be taken until transitioning is done

## Save Data
### Player preferences
	1. audio levels - master, music, sfx
	2. fullscreen setting (desktop build only)
### Progression
	1. progress of achievements
	2. what content is locked/unlocked
	3. Number of times beaten, best round beaten, lowest damage taken, etc
