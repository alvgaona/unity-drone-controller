# Unity Drone Controller

<p align="center"><img src="images/dji.gif"/></p>

The idea behind this project is to share a set-up for robotics simulation in Unity. 
At the time of this writing, this is simply a Unity-based drone controller—in particular a DJI F450 controller written in C#—which can be controlled
by any joystick you'd like; although, it's been only tested with a PS4 controller (it's pretty easy to set up a different one).

Keep in mind it's a very basic implementation, inspired by other people, in which you can control the drone's altitude and orientation with the joystick sticks.
Feel free to improve it!

## Requirements

To start running this project you need to fulfil a few steps.
Firstly, you've got to have Unity installed (obviously), and secondly, you should download the `Art` for the models.
There are only two models in the scene, the DJI F450 drone and the ground to collide with.

### DJI F450 Drone

The model was downloaded from [here][3DWarehouse DJI F450] (thanks Matheus Monteiro).
However, there are some caveats to use the model directly.
If you import either Collada or SketchUp files, the model won't be complete. 
So I fixed it and exported a Unity package based on a FBX file. Download it from this [link][F450 Unity package].

![DJI F450 Image]

### Ground

The ground is basically a 2D `GameObject` (a plane) with some texture on it.
Be sure to download the materials and the texture folders from [here][Ground Material/Textures].
You can place both `Material/` and `Textures/` folders within `Art/Ground` for instance.
Thanks [Indie Pixel] for the cool textures.

## PS4 Controller

The PS4 controller is connected directly by pairing it with a computer.
Once you've confirmed that the OS has recognized the device you just need to install the Unity Package called "Input System".
It can be installed via the package manager in Unity.

![New Input System Image]

The configuration for the drone inputs can be found this [directory][Drone Inputs].

## Future work

There are a few things that can be done based on this project.

1. Improve the physics of the drone.
2. Integrate Unity with ROS and implement algorithms to automatically control the drone (e.g. hovering).
3. Add a camera view to the GoPro Hero 4.
4. Create a more realistic scene around the model to make a better simulation.

<!-- Images -->
[DJI F450 Image]: images/dji-f450.png
[New Input System Image]: images/new-input-system.png

<!-- Internal links -->
[Drone Inputs]: drone_controller/Assets/F450_Controller/Input/F450_Inputs.inputactions

<!-- External links -->
[Indie Pixel]: https://www.youtube.com/channel/UC7P6olyswpgJlElZA6RXUNQ
[F450 Unity package]: bit.ly/3qasto4
[Ground Material/Textures]: https://bit.ly/2ImVLyU
[3DWarehouse DJI F450]: https://3dwarehouse.sketchup.com/model/c69f18fa-06b0-4074-bdf5-e383c0772c44/DJI-F450-Quadcopter
