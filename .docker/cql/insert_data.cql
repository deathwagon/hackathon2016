INSERT INTO seo.applications (app_id, app_name) VALUES (1, 'sales');
INSERT INTO seo.applications (app_id, app_name) VALUES (2, 'help');

INSERT INTO seo.pages (id, app_id, en_path) VALUES ('home', 1, '/');
INSERT INTO seo.pages (id, app_id, en_path) VALUES ('website-builder', 1, '/websites/website-builder');
INSERT INTO seo.pages (id, app_id, en_path) VALUES ('web-hosting', 1, '/hosting/web-hosting');