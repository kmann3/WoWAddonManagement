# WoWAddonManagement

### Screen shots

[Here is the Imgur album](https://imgur.com/a/ZnI5j) as of March 6, 2018.

### Goals

### Overview

* Lean UI. Quick to load. Curse was not quick and Twitch doesn't feel great.
* Easier ability to have people help via pull requests instead of having to rely on comments.
* Learn WPF because I'm curious if it's better than WinForms. Considered Universal Windows but that's too restrictuve due to Windows 10 only.
* Will consider Mac once the back-end is solidified.
* _But why Git?_: For the ability to fork, have pull requests, and issue tracking. The ultimate goal is to have the app assist in this so users can more easily communicate with devs, somehow. I haven't sorted all this out yet.
* _Isn't this going to be too complicated for users?_: The goal is to make it easy. If it can't be figured out how to make it super easy then this project will fail. The most complicated, that I feel is acceptable, is to make a github account. Everything outside of that should be able to be handled by the app outside of the more complicated tasks more advanced people would be interested in.

### Installed addons management

* Simple automatic update. Adjustable to turn off specific addons or hide them.
* If a change is detected then offer to make a pull request for changes. Required to note changes however.
* If ran in the background, can regularly check for updates and alert the user so they don't find out after loading WoW.

### Search Addons

* Search Catageories: Auction & Economy, Classes (specific addons to each), PvP,  (TBI: Enumerate full list)
* Display basic information of addons without actually having to load a browser. Screen shots and more detailed information will require them browse to the repository.
* Search hastag (TBI: search dll for plugins). [#wam-addon](https://api.github.com/search/repositories?q=wam-addon&order=desc)
* Maintain a databaase that can be downloaded. Database is in SQLite making it open and easy for anyone to fork this project and handle their own.

### Addon Developer assistance

* Import addons and link to github.
* Ability to handle basic git functionality so developers don't need to know CLI of simple tasks.
* Have basic readme.md file for addon developers to use to make documentation easy to read for users.

### Misc

* Ability to point to a a new or multiple search engines / databases? Will need to decide how to handle duplicates.
* Ability to upload statistical data to help maintain trackable items such as download count. Should this be opt-out or opt-in?
