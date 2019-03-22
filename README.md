# My Movies
## MoviesMobileApp

A Xamarin.Forms application to follow up all everything about movies!

At this very first version you can check all upcoming movies.

About next steps (or application roadmap) we can consider:

Features:
  - Search for specific movie;
  - Account management;
  - More interaction with TMDb API;
  - Rate a movie!

Application design:
  - a better aproach to deal with API error message;
  - enhance image perfomance through a internal Db;
  - enhance listview performance;
  - enhance iOS/Android UI.

### ML.Framework 

A micro framework designed to be light, fast and useful to build Xamarin.Forms applications using MVVM pattern approach.
Currently in beta version it will be made avaliable at nuget and github soon. 

Internal Features Already Included:
  - IoC Container Support using Simple Injector;
  - Simple Api REST connectors to get and post json with friendly respose pattern;
  - MVVM support page decoupling and View Model (helpfull ViewModelBase).
  

### Plugins

My Movies is currently extended with the following plugins. Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Xamarin.Essentials | [https://github.com/xamarin/Essentials][PlDb] |
| Plugin.Multilingual | [https://github.com/CrossGeeks/MultilingualPlugin][PlGh] |
| Newtonsoft.Json | [https://github.com/JamesNK/Newtonsoft.Json][PlGd] |


## To developers
 
 A few but important considerings:
 
 - Application should be enhance on iOS. Due to Mac Devices were not avaliable during this first release, iOS project may be not working well or even not running.
 - ML.Framework project would be removed from application soon and then will be treated as a particular solution with his own GitHub repo. ML.Framework will be refered as a Nuget package by My Movies app.

