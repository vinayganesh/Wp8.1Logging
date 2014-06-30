Wp8.1Logging
============

Logging is the most essential feature in the field of software development. When you are developing a windows phone application, it is really important that every action of the user of any particular app is logged. This is at the least to make sure that every event is captured and if there  are any errors or exceptions it is caught in the logs. 

WriteToText is a sample application that can be used to log every activity that occurs in the application. This application, creates a sample text file which logs sample text into the file and it logs the exceptions as well. 

Update:
=======
Application can save the log file to local storage instead of picture library. The log files can be retrieved using the tools like isoStoreSpy. Its a pretty darn good tool to extract the log files. 

Using C# 5's feature of CallerMembername, the method which is logging can also be used. This is very useful when it comes to Windows Runtime Project because there is not support for StackTrace API. 
