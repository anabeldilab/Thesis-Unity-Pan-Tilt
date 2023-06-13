# Bachelor's Degree Thesis: Control of Electromechanical Devices using BCI - Unity Part

## About
This repository contains the Unity portion of the Bachelor's Degree Thesis project on controlling electromechanical devices using Brain-Computer Interface (BCI). This project involves two key components: ROS nodes and a Unity application. This repository specifically covers the Unity application.

The Unity application serves as the interface for BCI control. We've chosen Unity for this part of the project because NextMind, the BCI device we're using, only supports development through Unity at this time.

## Unity Application
The Unity application I'm building hosts four neurotags for the user to interact with. Each neurotag is associated with a specific command that will be sent to an electromechanical pan-tilt device. The application utilizes the ROS2-For-Unity library to facilitate communication between the Unity application and the ROS nodes controlling the pan-tilt device.

## Version
This project uses Unity version 2020.3.14f1.

## Prerequisites
To run this project, you will need:

Unity 2020.3.14f1
NextMind SDK installed and set up in Unity
ROS2-For-Unity library installed in Unity

## Installation
Detailed instructions for how to install and setup the project will be added soon.

## Usage
In order to use this application, you must first ensure that the NextMind device is properly fitted to your head, as it serves as the primary interface for interaction. This process is critical for the accurate functioning of the system.

The calibration process can be accessed directly from the application's menu within the Unity environment that I have developed. Follow the guided instructions to properly calibrate the NextMind device.

Once the NextMind device is calibrated, you can proceed to the device control section of the application. Here, you will find four buttons displayed, each corresponding to one of the four available directions for controlling the pan-tilt device: up, down, left, and right.

When you focus on one of these buttons with the NextMind device, a command will be sent from Unity to the pan-tilt device via ROS nodes. This command will prompt the device to execute the corresponding movement.

## Future Works
Plans for expanding and improving the project will be added soon.

## Authors and Acknowledgment
This project is authored by Anabel Díaz Labrador. I'd like to express my deep gratitude to several important individuals in my life who have provided me with invaluable support during the development of this thesis.

First and foremost, I owe a great deal to my boyfriend. As my life and academic partner, he has been there every step of the way throughout this journey, providing unwavering support, patience, and understanding. His contributions have been invaluable to the completion of this project.

Next, my sincere thanks go to my parents for their continuous encouragement and belief in me.

I am also grateful to my academic tutor, Nacho, for his guidance and expertise that greatly contributed to my project.

Finally, a big thanks to all of my friends who have put up with me throughout this process.

## License
This project is licensed under the GNU General Public License Version 3, dated 29 June 2007. For more information, please see the LICENSE file in this repository or visit https://www.gnu.org/licenses/gpl-3.0.html.

