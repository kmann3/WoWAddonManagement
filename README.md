# WoWAddonManagement
WoW Addon Manager


## Goals

### Overview

* Lean UI. Quick to load. Curse was not quick and Twitch doesn't feel great.
* Easier ability bo have people help.


### Installed addons management

* Simple automatic update. Adjustable to turn off specific addons or hide them.
* If a change is detected then offer to make a pull request for changes. Required to note changes however.
* If ran in the background, can regularly check for updates and alert the user so they don't find out after loading WoW.


### Search Addons

* Search Catageories: Auction & Economy, Classes (specific addons to each), PvP,  (TBI: Enumerate full list)
* Display basic information of addons without actually having to load a browser. Screen shots and more detailed information will require them browse to the repository.
* Search database or hashtag on git hub? Perhaps just allow for DLL's and call a method instead to allow for plugins?
* Maintain a databaase that can be downloaded. Database is in SQLite making it open and easy for anyone to fork this project and handle their own.

### Addon Developer assistance

* Import addons and link to github.
* Ability to handle basic git functionality so developers don't need to know CLI of simple tasks.
* Have basic readme.md file for addon developers to use to make documentation easy to read for users.

### Misc

* Ability to point to a a new or multiple search engines / databases? Will need to decide how to handle duplicates.
* Ability to upload statistical data to help maintain trackable items such as download count. Should this be opt-out or opt-in?
