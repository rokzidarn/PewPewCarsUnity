2016 Spyblood Games

Thank you for downloading this asset!

The purpose of this asset is adding a boost, or nitro system to your racing games to make them a bit faster.

This package is compatible with almost every car controller, and any vehicle type.
It just needs a Rigidbody, and Wheel Colliders. (optional). That's It!

NOTE: This package contains an edited version of Unity's Standard Asset Car as the testing subject/example.

SETUP:

It's simple! just go to the prefabs folder, and drag the "Car" file and place it in your scene,
along with the "Main Camera Rig" object, and you're ready to go! Or, you can go to one of the
scenes provided and play around from there.

CUSTOM SETUP:

For those of you who have your own vehicle setup and have no idea on how to rig the boost system to it,
follow this simple tutorial.

NOTE: if you dont know how to set up a car from scratch, I will not be covering that now, but please check out my
other packages to see how that's done, or classicaly, just Google it.

STEPS:

1.start with a fresh new scene

2.get your car and drag it into the scene

3.Drag the "BoostBarCanvas" from the prefabs folder into the scene. This is a crucial step

4.Get the "BoostFlames" particle system object from the same folder, and parent it to the car.

5. this step might get a little personal. Use the axis widget to drag the flames to where you think the "Exhaust" region of the car might be. Or just put them in the middle of space for all I care. 

6.Find the CarBoostSystem script from the scripts folder and assign it to your car.

7. Select your car object, right click on it, and select "Create Empty". This will be the nitro audio source for our car.

8. Rename that object to "boostAudio", and add and Audio Source component to it.

9. Set the audio clip to the boosting sound, (found in the SFX folder), and set the volume to something like 0.25.

10. select the car object with the CarBoostSystem script, and assign that GameObject you just created earlier to the "Audio Obj" slot;

11. Now's when you might want to tweak the values. To be realistic, I usually set the Boost Power var to a value between 15-25.

12. For the "Consumption Rate" var, I usually set it to a value between 0.1-0.5;

13. For the "Flames" Array var, enter the number of BoostFlames object you have in your car, and assign them.The order doesn't matter.

14. For the "Boost Bar" variable, go to the BoostBarCanavs object in the scene, open it up, and assign the "Filler" object to the "Boost Bar" slot.

15. Go to the prefabs folder and drag the BoostButton prefab into the scene. (Dont worry if you dont want mobile controls, the script will take care of everything.)

16. For the "Speed" variable, go back the the BoostBarCanvas, and assign that slot with the "SpeedText" GameObject.

17. Here's the fun part. You can go to the "Flame Color" variable, and choose your color. The color you pick will be the color of the flames and of the boost bar itself. (IMPORTANT: make sure there is no alpha (transparency) on the color, or you wont be able to see anything).

18. Drag the "Main Camera Rig" from the prefabs folder into the scene, and Assign the Car transform var to your car object

19. Hit play, and everything should be running fine.



again, thank you for downloading this asset!

Got any questions?

Contact me at melvinjames885@gmail.com.
