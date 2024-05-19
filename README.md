# Challenge For Unity Frontend Engineer
## Assignment
This is a challenge for Unity Frontend Engineer.
The goal is to create a clock app with functionalities like modern mobile clock apps:
- Display current time
- Timer (countdown)
- Stopwatch (count up) with lap time
- Alarm
## Additional questions
- ### This application will be used on iOS/iPad devices. Do you have any concern for UI?
  - My biggest concern about UI on IPhone and IPad is the Retina display. The problem is that hardware reports the different (lower) resolution, not the real one". We should use high-resolution images and icons to make the app look good on these devices. We can modify Unity Canvas Scaler, add a "retina scale factor" to make ui resize less painful. One more option is to correctly setup sprites while importing them to Unity by setting Pixel Per Unit value to 200 or 300.
  - The second concern is the safe area on the top of the screen. We should keep that in mind while designing the UI.
  - Also IPads often used in landscape mode, so we should make sure that the app looks good in both portrait and landscape mode.
- ### How would you refactor the code and/or project after release? What would you prioritize as “must happen” versus “nice to have” changes
  - #### Must happen:
  - Alarm screen should not block stopwatch.
  - New feature: Add a world clock feature. Users can add multiple cities to the clock app and see the time in these cities.
  - New feature: Add possibility to set and manage multiple timers.
  - New feature: Add alarm clock feature. Users can set multiple alarms.
  - Alarm dont work when the app is closed. We should add local notifications to make it work.

  - #### Nice to have:
  - New feature: sorting the stopwatch lap times.
  - Checking time through the internet to make sure that the time is correct.

- ### [Optional] This application will be used on VR application. Share your concern and your opinion on what need to take into account to support it in VR?
  - The first thing that comes to my mind is the canvas size. I've read that the global size is 3600 × 1800 pixels, but the recommended size of "UI in focus" is 1200 × 600 pixels. We should keep that in mind while designing the UI. 
  - Because of the VR low resolution we should be concerned about the text readability. We should use a bigger font size and make sure that the text is clear and easy to read.
  - Of course the control system in VR is different than in mobile devices. But we can use default buttons. I am worried about the timer input. It may be hard to set the timer in VR.