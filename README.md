# ANI AI Practical Exam
Practical exam for animation and ai 2025, Charleen Chu, 100784133

I wasn't sure what caused the 2nd building to dissapear during play, since the building looks normal in the scene view.

I managed to get the player move using mouseclick (albeit janky probally due to adding a mesh collider to the buildings).

The player can crouch using leftshift, and when touching a weapon, pressing E will grab it (hold the E you can see the hand IK move to the object, it will dissapear/disabled when letting E go).

Enemies unfortunately the ones I imported does not have any animation controller, and I tried to apply an avatar to them to at least get them walk, but it doesn't work due to rig and bones differences. (Just found out they do have an animation, I guess my import was faulty...?).

Enemies do patrol around using the waypoint system. There was a collision system for the buildings (Using tags At A, At B, At C to represents buildings A, B, C), which was initally for the camera animations. I regret that I disabled it due to complications with the camera animations, and looking back I should've use it for the enemies detection (if character is colliding with building B, target is player). I eventually forgotten it when recording the video, which is why they don't chase the player (but they COULD HAVE AHHHHHHHH).

Character can jump between buildings based on where you click

As said before, the camera animation controller and script was disabled (still in project however), I instead parented it to the player as the last resort (very sad about this too).

Player can swap between two weapons (bow and shield), using key 1 and 2 (not numpad).

I couldn't add environmental stuff, but I intend to use the spline system to move them around. The only thing I did for this is importing the spline system package. I was too focused on other parts that I neglected this (also sad bout this too).
