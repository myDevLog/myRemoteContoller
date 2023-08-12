# myRemoteContoller
This Repository is the code-basis for an app to control all my RC Vehicles.

... one App, to rule them all

<br>

## Used Framework:
To create this controller, i have chosen _Flutter_ over _React Native_:

Benefits:
- a lot of _React_ Libraries apparently aren't compatible with _React Native_
- better DX (better static analysis, more extensive documentation, e.g)
- it doesn't use `npm` as package manager
- i don't like java script, because it's unnecessarily overcomplicated and it hurts mi brain

Drawbacks:
- have to learn new language, dart
- promotes heavy nesting

<br>

## Personal goals for this project:
1. Clean Code. In the past i always got lost in my own code, therefore i want to:
    1. Write self-documenting code
    2. Keep my nesting as low as possible
    3. Use the single responsibility principle for every function
    4. Give variables, functions and classes meaningful names
2. Use patterns and tactics when beneficial, to learn about them and their implementation

<br>

## Specifications:
- [ ] One screen which lists the different controlviews for different RC-vehicles
- [ ] Listed views should contain a name and a image 
- [ ] Controlviews should be listed automatically with name and image
- [ ] Views should be flexably positioned across the screen
- [ ] List of views should be scrollable if to many for screensize
- [ ] Should work on IOS and Android
- [ ] Should remember the previously selected controlview
- [ ] Mobile-First approach, then Tablet, probably no Desktop
- [ ] View should adjust with the rotation of the device
