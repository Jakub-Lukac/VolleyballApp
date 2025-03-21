# VolleyballApp

### User stories

1. **Games feature**
   As a sport enthusiastic I want to be able to see which matches are happening on a specific day,
   I would also like to filter the based on the state (Finished, Live, Scheduled, ...) so I can plan what and when to watch.

2. **Rosters feature**
   As a volleyball coach I wish to create different rosters for my team so I can prepare different tactics for matches.

3. **Exercises feature**
   As a volleyball player I would like to have a list of exercises I could do alone or with someone, and filter them
   based on difficulty, so I can get better at the game.

### Objects

1. **Objects for API handling**

   1.1 For fetching games

   - GamesReponse
   - Game
   - GameStatus
   - GameLeague
   - Teams
   - Team
   - Scores
   - Periods
   - Period

     1.2 For fetching leagues

   - LeagueResponse
   - League
   - CountryInfo

2. **Other Objects**

   - Player
     - Position (enum)
   - Roster
   - Exercise
     - Difficulty (enum)

# VolleyballAPI Service

## Overview

The VolleyballAPI service provides an interface to fetch volleyball-related data from the api-sports.io API. It enables retrieving games and league logos using asynchronous HTTP requests.

## Features

Fetch games based on a given date.

Retrieve league logos using league IDs.

Uses HttpClient for making API requests with appropriate headers and timeout settings.

Secure API key handling through environment variables.

## Prerequisites

.NET 6.0 or later

An API key from api-sports.io

Environment variable API_KEY set with the API key

## Usage

### Fetching Games by Date

```
var games = await VolleyballAPI.GetGamesAsync("2025-03-18");
foreach (var game in games)
{
    Console.WriteLine($"{game.Team1} vs {game.Team2} - {game.Date}");
}
```

### Fetching League Logos

```
List<int> leagueIds = new List<int> { 1, 2, 3 };
var leagues = await VolleyballAPI.GetLeaguesLogosAsync(leagueIds);
foreach (var league in leagues)
{
    Console.WriteLine($"League: {league.Name}, Logo: {league.Logo}");
}
```

## API Structure

### GetGamesAsync(string date)

Fetches volleyball games for a specific date.

Parameters: date (string) - The date in YYYY-MM-DD format.

Returns: `Task<List<Game>>` - A list of games.

### GetLeaguesLogosAsync(List<int> leagueIds)

Retrieves league logos for given league IDs.

Parameters: leagueIds (List<int>) - A list of league IDs.

Returns: `Task<List<League>>` - A list of league details including logos.

## Error Handling

Ensures successful HTTP responses using response.EnsureSuccessStatusCode().

Uses try-catch (recommended to implement) to handle request failures.

# GamesViewModel

## Overview

The GamesViewModel class is responsible for managing the state and logic of the volleyball games view in the application. It interacts with the DataService to fetch leagues and games, providing filtering options for users based on game status and date.

## Features

Fetch and display a list of volleyball leagues.

Load games based on the selected league and date.

Filter games by status (All, Live, Canceled, Finished).

Uses CommunityToolkit.Mvvm for observable properties and commands.

## Prerequisites

.NET 6.0 or later

CommunityToolkit.Mvvm package installed

DataService implemented to fetch league and game data

## Properties

**Leagues** (ObservableCollection)

Stores the list of available leagues fetched from the API.

**Games** (ObservableCollection)

Stores the list of games based on the selected league, date, and filter.

**Filters** (List)

A predefined list of game filters: All, Live, Canceled, Finished.

**SelectedFilter** (string)

The currently selected filter (default is All).

**SelectedLeague** (League)

The currently selected league for fetching games.

**SelectedDate** (DateTime)

The selected date for filtering games (default is today).

## Commands

**SelectLeagueCommand**

Description: Sets the selected league and loads corresponding games.

Parameters: League selectedLeague

### Usage:

```
SelectLeagueCommand.Execute(myLeague);
```

**SelectFilterCommand**

Description: Changes the selected filter and reloads games accordingly.

Parameters: string filter

### Usage:

```
SelectFilterCommand.Execute("Live");
```

**SelectDateCommand**

Description: Changes the selected date and reloads games.

Parameters: DateTime date

### Usage:

```
SelectDateCommand.Execute(DateTime.Now.AddDays(-1));
```

## Methods

**LoadLeaguesAsync()**

Description: Fetches available leagues asynchronously and updates the Leagues collection.

### Usage: Called in the constructor.

**LoadGames()**

Description: Fetches games based on the selected league, date, and filter.

### Usage: Called when the user selects a league, filter, or date.

## Filtering Logic:

**Live**: Games with status S1, S2, S3, S4, S5

**Canceled**: Games with status CANC

**Finished**: Games with status FT

**All**: Displays all games

## Usage Example

```
var viewModel = new GamesViewModel(dataService);
viewModel.SelectLeagueCommand.Execute(selectedLeague);
viewModel.SelectDateCommand.Execute(DateTime.Now);
viewModel.SelectFilterCommand.Execute("Live");
```

## Error Handling

Ensures Games is cleared if no league is selected.

Uses await for asynchronous data fetching to prevent blocking UI.

# Dependency Injection (DI) in VolleyballApp

## Overview

**Dependency Injection (DI)** is used in VolleyballApp to manage dependencies efficiently. It improves modularity, testability, and maintainability by ensuring that components receive their dependencies from an external source rather than creating them internally.

The application utilizes Microsoft.Extensions.DependencyInjection for setting up DI, allowing seamless integration of services, view models, and views.

## Why Use Dependency Injection?

**Decouples components** → Reduces tight coupling between classes.
**Improves testability** → Dependencies can be mocked for unit testing.
**Enhances maintainability** → Easier to update and modify services.
**Centralized configuration** → All services are registered in one place.

## How Dependency Injection Works in the App

Services, ViewModels, and Views are registered in **\*ServiceCollectionExtensions.ConfigureServices().**
App initializes DI, builds the service provider, and resolves MainWindow.
When a **ViewModel** is needed, the system automatically injects its dependencies **(e.g., GamesViewModel receives DataService).**

## Example: Injecting a Service into a ViewModel

Instead of manually creating a **DataService instance** inside GamesViewModel, DI provides it automatically.

```
public partial class GamesViewModel : ObservableObject
{
    private readonly DataService _dataService;

    public GamesViewModel(DataService dataService)
    {
        _dataService = dataService;
        _ = LoadLeaguesAsync();
    }
}
```
