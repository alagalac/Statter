  CREATE TABLE [stats] (
	id integer IDENTITY(1,1) NOT NULL,
	name varchar(80) NOT NULL,
	[description] varchar(255) NOT NULL,
	stat_type varchar(25) NOT NULL,
	unit varchar(25) NOT NULL,
  CONSTRAINT [PK_STATS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

  CREATE TABLE [stat_count_values] (
	id integer IDENTITY(1,1) NOT NULL,
	stat_id int NOT NULL CONSTRAINT FK_COUNT_STATS_ID FOREIGN KEY REFERENCES stats (id),
	date_created datetime2 NOT NULL,
	value bigint NOT NULL,
  CONSTRAINT [PK_STAT_COUNT_VALUES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

  CREATE TABLE [stat_measure_values] (
	id integer IDENTITY(1,1) NOT NULL,
	stat_id int NOT NULL CONSTRAINT FK_MEASURE_STATS_ID FOREIGN KEY REFERENCES stats (id),
	date_created datetime2 NOT NULL,
	value decimal(19, 4) NOT NULL,
  CONSTRAINT [PK_STAT_MESAURE_VALUES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

  CREATE TABLE [stat_countdown_values] (
	id integer IDENTITY(1,1) NOT NULL,
	stat_id int NOT NULL CONSTRAINT FK_COUNTDOWN_STATS_ID FOREIGN KEY REFERENCES stats (id),
	date_created datetime2 NOT NULL,
	value datetime2 NOT NULL,
  CONSTRAINT [PK_STAT_COUNTDOWN_VALUES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO