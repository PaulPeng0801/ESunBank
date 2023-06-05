CREATE TABLE [dbo].[FutureWeather] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [City]       VARCHAR (50) NOT NULL,
    [StartTime]  DATETIME     NOT NULL,
    [EndTime]    DATETIME     NOT NULL,
    [Weather]    VARCHAR (50) NOT NULL,
    [CreateTime] DATETIME     NOT NULL,
    CONSTRAINT [PK_FutureWeather] PRIMARY KEY CLUSTERED ([Id] ASC)
);

