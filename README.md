# Juice
The goal of this repo is to give me the opportunity to try out things I would not otherwise and also result in applications that I will hopefully use quite a bit.

The intention is to create a suite of apps to manage my music library I want to build this very modular so that once the basic building blocks are there I can work on whatever part I feel like at the time.

The following is a description of the modules that I intend to implement at some point.

## MusicPlayerBackend
This is supposed to be a UI- and Platform-independent library to enable playback of audio files. This will be the core library for all other apps to use.

## Player for Desktop
This will be a Desktop Application for music playback. I hope to be able to do this in MAUI so that I can combine it with the next feature on the list.
This will probably also include some functionality to create playlists, but this might also move to the LibraryManagement-App.

## Player for Android
This should get about the same features as the desktop app (Playlist building might not be on the table considering the screen size I am going for). Hopefully a lot of the work from the desktop app can be reused due to the use of MAUI.

## LibraryManagement
This will probably be a Desktop application (I am thinking WPF; maybe MAUI depending on how well I get along with it on the Player App)
to manage the library. I will mostly use this to build the library from scratch and add tags (possibly lyrics) and other additional data to each song.

## Features I want to include at some point
I have these features at the back of my mind and want to try and implement them but maybe not all of them will make it into the first iteration.

### Library as database with Entity Framework
I do have quite a bit of song data from an earlier iteration of this project in one big json file. I want to migrate this data into a real database and use this opportunity to get to know entity framework.
This one has the best chance to make it into the first iteration of all the features.

### Static and dynamic playlist support
With static playlists I mean the usual fixed list of songs to make up a playlist. Far more interesting to me is the idea of a dynamic playlist that ist defined for example as "all songs that are tagged as 'uplifting' and have a rating of 7 or higher".
That kind of playlist would change when new songs are added or ratings/tags change.

### Probably more once I think of it.


