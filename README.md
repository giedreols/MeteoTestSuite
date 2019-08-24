# MeteoTestSuite

MeteoTestSuite demonstrate a few simple Selenium tests (C#) for http://meteo.lt site

## Installation

1. Install Visual Studio
 * Instruction: https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2017
 * Target framework: .NET Framework 4.6
2. Install the latest versions of Chrome, Firefox and Internet Explorer browsers

## Usage

1. Open solution file in Visual Studio
2. Select Test -> Run -> All Tests (Ctrl R+A)
3. After tests running go to \MeteoTestSuite\MeteoTestSuite\bin\Debug\Result
 * Full log in Meteo.log file
 * Screenshots of failed tests in /Screenshots folder
 
## Configuration

In App.config file you can change:
1. Browser type: set SeleniumBrowser as Chrome, Firefox or Internet Explorer
2. Default wait (the same for ImplicitWait and WebLoadWait): set DefaultWaitMs in milliseconds
3. Minimum window width: set MinWindowWidth in pixels
4. Minimum window height: set MinWindowHeight in pixels
