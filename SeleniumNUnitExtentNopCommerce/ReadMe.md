POM Automation Framework Selenium WebDriver in C# with Extent Reports
===========

This repository is a POM automation framework template. It runs test against the popular ecommerce template NopCommerce (installed locally).

Environment settings, user credentials are listed in the RunSettings file, which can be selected for running test in Visual Studio or in command line.

Extent reports are generated after the test.

Currently the framework supports the Chrome and FireFox browser  

## Command line example for running the test

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" --settings:"F:\VS-projects\SeleniumNUnitExtentNopCommerce\SeleniumNUnitExtentNopCommerce\RunSettings\FireFoxTest.runsettings" "F:\VS-projects\SeleniumNUnitExtentNopCommerce\SeleniumNUnitExtentNopCommerce\bin\Debug\SeleniumNUnitExtentNopCommerce.dll" 

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" --settings:"F:\VS-projects\SeleniumNUnitExtentNopCommerce\SeleniumNUnitExtentNopCommerce\RunSettings\ChromeTest.runsettings" "F:\VS-projects\SeleniumNUnitExtentNopCommerce\SeleniumNUnitExtentNopCommerce\bin\Debug\SeleniumNUnitExtentNopCommerce.dll" 


