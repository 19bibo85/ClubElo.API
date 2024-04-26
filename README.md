# ClubElo.API

It's a **C#** library that allows you to send requests to the [ClubElo API](http://clubelo.com/API).

## How to get the Elo ranks by team?

You can get the Elo ranks by team by creating an instance of the `ClubEloHttpClient` class and calling the `GetClubEloRanksByTeamAsync` method.

```cs
var client = new ClubEloHttpClient();  	

var result = await client.GetClubEloRanksByTeamAsync("ManCity");
```

## How to get the Elo ranks by date?

You can get the Elo ranks by date by creating an instance of the `ClubEloHttpClient` class and calling the `GetClubEloRanksByDateAsync` method.

```cs
var client = new ClubEloHttpClient();  	

var result = await client.GetClubEloRanksByDateAsync("2024-01-01");
```

Notice tha the date must be in the format yyyy-MM-dd (2024-01-01).

## How to get the Elo features?

You can get the Elo features by creating an instance of the `ClubEloHttpClient` class and calling the `GetClubEloFixturesAsync` method.

```cs
var client = new ClubEloHttpClient();  	

var result = await client.GetClubEloFixturesAsync();
```

## How can I check the status of the request?

All methods return a `ClubEloResult` object, by default the propert `Success` is set to `True` and the `Message` to `OK`, when an error occurs `Success` is set to `False` and details of the error can be found in `Message` property.

## Notes

For a full reference of all the `ClubEloRank` and `ClubEloFixture` propeties please visit [ClubElo API](http://clubelo.com/API)
