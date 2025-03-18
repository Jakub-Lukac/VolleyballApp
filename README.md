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

Returns: ```Task<List<Game>>``` - A list of games.

### GetLeaguesLogosAsync(List<int> leagueIds)

Retrieves league logos for given league IDs.

Parameters: leagueIds (List<int>) - A list of league IDs.

Returns: ```Task<List<League>>``` - A list of league details including logos.

## Error Handling

Ensures successful HTTP responses using response.EnsureSuccessStatusCode().

Uses try-catch (recommended to implement) to handle request failures.
