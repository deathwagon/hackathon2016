CREATE TABLE seo.applications (
	app_id int PRIMARY KEY,
	app_name text
);

CREATE TABLE seo.pages (
	id text PRIMARY KEY,
	app_id int,
	en_path text
);

CREATE INDEX ON seo.pages( app_id );

CREATE TABLE seo.pages_data (
	page_id uuid,
	market text,
	version int,
	market_path text,
	data map<text, text>,
	PRIMARY KEY (page_id, market, version)
);

CREATE INDEX ON seo.pages_data( market );

CREATE TABLE seo.pages_data_active (
	app_id int,
	page_path text,
	market text,
	version int,
	market_path text,
	data map<text, text>,
	PRIMARY KEY (app_id, page_path, market)
);