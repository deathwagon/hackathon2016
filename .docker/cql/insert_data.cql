INSERT INTO seo.applications (id, app_name) VALUES (1, 'sales');
INSERT INTO seo.applications (id, app_name) VALUES (2, 'help');



INSERT INTO seo.pages (id, app_id, path) VALUES ('website-builder', 1, '/websites/website-builder');
INSERT INTO seo.pages (id, app_id, path) VALUES ('web-hosting', 1, '/hosting/web-hosting');

INSERT INTO seo.pages (id, app_id, path) VALUES ('680', 2, '/manage-dns-680');
INSERT INTO seo.pages (id, app_id, path) VALUES ('420', 2, '/add-private-registration-420');




INSERT INTO seo.pages_data (app_id, page_id, market, version, market_path, data) VALUES (1, 'website-builder', 'en-US', 1, '/websites/website-builder', null);
UPDATE seo.pages_data
  SET data =
  { 'title' : 'Website Builder',
    'meta-description' : 'Build your website now fast and easy.' }
  WHERE page_id = 'website-builder' AND app_id = 1 AND market = 'en-US' AND version = 1;

INSERT INTO seo.pages_data (app_id, page_id, market, version, market_path, data) VALUES (1, 'website-builder', 'es-ES', 1, '/sitios-web/constructor-de-sitio-web', null);
UPDATE seo.pages_data
  SET data =
  { 'title' : 'Constructor De Sitio Web',
    'meta-description' : 'Construir su sitio web ahora rapido y facil.' }
  WHERE page_id = 'website-builder' AND app_id = 1 AND market = 'es-ES' AND version = 1;

INSERT INTO seo.pages_data (app_id, page_id, market, version, market_path, data) VALUES (1, 'web-hosting', 'en-US', 1, '/hosting/web-hosting', null);
UPDATE seo.pages_data
  SET data =
  { 'title' : 'Web Hosting',
    'meta-description' : 'Host your website with 99.9% uptime and blazing fast performance.' }
  WHERE page_id = 'web-hosting' AND app_id = 1 AND market = 'en-US' AND version = 1;

INSERT INTO seo.pages_data (app_id, page_id, market, version, market_path, data) VALUES (1, 'web-hosting', 'es-ES', 1, '/hospedaje/web-hosting', null);
UPDATE seo.pages_data
  SET data =
  { 'title' : 'Web Hosting',
    'meta-description' : 'Hospedaje de su sitio web con 99,9% y un rendimiento ultrarrapido.' }
  WHERE page_id = 'web-hosting' AND app_id = 1 AND market = 'es-ES' AND version = 1;




INSERT INTO seo.pages_data_active (app_id, page_id, market, version, market_path, data) VALUES (1, 'website-builder', 'en-US', 1, '/websites/website-builder', null);
UPDATE seo.pages_data_active
  SET data =
  { 'title' : 'Website Builder',
    'meta-description' : 'Build your website now fast and easy.' }
  WHERE page_id = 'website-builder' AND app_id = 1 AND market = 'en-US';

INSERT INTO seo.pages_data_active (app_id, page_id, market, version, market_path, data) VALUES (1, 'website-builder', 'es-ES', 1, '/sitios-web/constructor-de-sitio-web', null);
UPDATE seo.pages_data_active
  SET data =
  { 'title' : 'Constructor De Sitio Web',
    'meta-description' : 'Construir su sitio web ahora rapido y facil.' }
  WHERE page_id = 'website-builder' AND app_id = 1 AND market = 'es-ES';

INSERT INTO seo.pages_data_active (app_id, page_id, market, version, market_path, data) VALUES (1, 'web-hosting', 'en-US', 1, '/hosting/web-hosting', null);
UPDATE seo.pages_data_active
  SET data =
  { 'title' : 'Web Hosting',
    'meta-description' : 'Host your website with 99.9% uptime and blazing fast performance.' }
  WHERE page_id = 'web-hosting' AND app_id = 1 AND market = 'en-US';

INSERT INTO seo.pages_data_active (app_id, page_id, market, version, market_path, data) VALUES (1, 'web-hosting', 'es-ES', 1, '/hospedaje/web-hosting', null);
UPDATE seo.pages_data_active
  SET data =
  { 'title' : 'Web Hosting',
    'meta-description' : 'Hospedaje de su sitio web con 99,9% y un rendimiento ultrarrapido.' }
  WHERE page_id = 'web-hosting' AND app_id = 1 AND market = 'es-ES';