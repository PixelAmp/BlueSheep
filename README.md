# BlueSheepMobile
This is the repository for the Blue Sheep, an application for permission awareness. 
This application was created at CSU San Marcos in Fall 2017 for CS 441 Software Engineering.
The purpose of this project is to allow users to see how much information they unknowingly produce through their phone's’ various sensors. 
Once the data is collected, it is sent to an Amazon AWS Server where we use various algorithms to make the data collected comprehensible through the use of charts that show how a user's phone can phone interprets their habits.
The mobile application is written in Xamarin, thus will be simultaneously deployed as an app for the Android and iOS, allowing us to reach a larger audience and have a universal interface.
Server is hosted on an Amazon AWS EC2 instance where we have python scripts parsing through and converting the recived log files into something our users can interpret.
