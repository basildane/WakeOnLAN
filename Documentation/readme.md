# WakeOnLAN 2.11.0

## Beta 22 - _Mar 27 2015_

* Fix problem with threadpool not pinging every machine in the queue.


## Beta 20 - _Mar 24 2015_

* New installer based on Inno Setup.
* Installer is multilingual.  Installation language carries over to the WOL program.
* New scheduler option to send messages to machines.
* New feature: managed thread pool.  The polling of machines is now managed so that it doesn't overload network.
 You can select how many machines are pinged simultaneously (default is 10).


## Beta 10 - _Mar 12 2015_

* A lot of fixes to popup messaging system.
* Added ability to schedule messages to multiple hosts.


# WakeOnLAN 2.10.19

## Beta 21 - _Mar 5 2015_

* Major code rewrites for the shutdown module, messaging, and properties pages.
* Legacy shutdown and reboot modes now supported in command-line and scheduler.

![Properties](https://sourceforge.net/p/aquilawol/discussion/1105198/thread/d64df5ff/e64c/attachment/Capture.PNG)

------

## Beta 15 - _Mar 3 2015_

* Shutdown for Workgroups.  To use this, open properties for the host you want to shutdown.
Click on "Password".  Enter a userid and password.  You can leave the domain blank.
Click on Shutdown Method, select "Legacy".

## Beta 10 - _Mar 1 2015_

* Testing new ideas for Shutdown on Workgroup type computers.


# WakeOnLAN 2.10.18

## Beta 40 - _Feb 24 2015_

* Enhanced Listener. Now displays more useful data from captured packets.
* Added "Clear-IP" function to main window context menu.  Used to remove IP address from DHCP hosts.

## Beta 35 - _Feb 23 2015_

* Command-line program displays the broadcast subnet on wakeup command.

## Beta 32 - _Feb 20 2015_

* Database path is shared between installer and WOL.
* Can now have a custom DB filename, and it is preserved between versions.
