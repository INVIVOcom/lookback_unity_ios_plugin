# Lookback Unity Plugin for iOS
A plugin for Unity3D that integrates the Lookback SDK into an iOS build.

## Installation
1. Clone the contents of the repository to `<YOUR_PROJECT>/Assets/`
2. Download the Lookback iOS SDK from https://lookback.io
3. Create a folder in `YOUR_PROJECT/Assets/` called Lookback_ObjC, and copy the contents of the Lookback iOS SDK zip to this folder.
4. In Unity, find `Lookback_ObjC/lookback/HD/Lookback.framework` and `Lookback_ObjC/lookback/Safe/Lookback.framework`, and uncheck all of the boxes under 'Select platforms for plugin' in the Inspector

## Note
Within the app, you must set the Screen Capture mode to either 'Picard' or 'Kirk' - otherwise your recording of the Unity window will appear black.  This is a temporary workaround, as OpenGL is not officially supported by Lookback currently.

To change the Capture Mode, open the feedback bubble and go to *Recordings > Settings > Developer > Screen Capture*

## Usage
Initialize the plugin with:

    void InitializeLookback(string sdkToken);

Call this before any of the other provided functions

Enable or disable the 'shake to record' functionality:

    void SetShakeToRecord(bool shakeToRecord);


Set the visibility of the feedback bubble:

    void SetFeedbackBubbleVisible(bool feedbackBubbleVisible);


Customize the foreground and background colours of the feedback bubble:

    void SetFeedbackBubbleForegroundColour(float r, float g, float b, float a);

    void SetFeedbackBubbleBackgroundColour(float r, float g, float b, float a);


Log when a user has entered, or exited a view:

    void EnteredView(string viewIndentifier);

    void ExitedView(string viewIdentifier);


Accessors:

    bool ShakeToRecord();

    bool FeedbackBubbleVisible();


## License

Copyright (c) 2015 INVIVO Communications Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
