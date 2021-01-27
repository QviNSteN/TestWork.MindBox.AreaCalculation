--Стартовые параметры:

CREATE TABLE IF NOT EXISTS "Products" (
  "Id" int(6) unsigned NOT NULL,
  "Name" varchar(200) NOT NULL,
  PRIMARY KEY ("Id")
) DEFAULT CHARSET=utf8;
INSERT INTO "Products" ("Id", "Name") VALUES
  ('1', 'Product 1'),
  ('2', 'Product 2'),
  ('3', 'Product 3'),
  ('4', 'Product 4'),
  ('5', 'Product 5');

  CREATE TABLE IF NOT EXISTS "Product2Category" (
  "ProductId" int(6) NOT NULL,
  "CategoryId" int(6) NOT NULL
);
INSERT INTO "Product2Category" ("ProductId", "CategoryId") VALUES
  ('1', '1'),
  ('1', '2'),
  ('1', '3'),
  ('2', '4'),
  ('5', '5'),
  ('5', '1');
  
  CREATE TABLE IF NOT EXISTS "Category" (
  "Id" int(6) unsigned NOT NULL,
  "Name" varchar(200) NOT NULL,
  PRIMARY KEY ("Id")
) DEFAULT CHARSET=utf8;
INSERT INTO "Category" ("Id", "Name") VALUES
  ('1', 'Category 1'),
  ('2', 'Category 2'),
  ('3','Category 3'),
  ('4', 'Category 4'),
  ('5', 'Category 5');

--Сам код запроса

SELECT
P."Name",
C."Name"

FROM "Products" as P
LEFT JOIN "Product2Category" as P2C on  P."Id" = P2C."ProductId"
LEFT JOIN "Category" as C on  P2C."CategoryId" = C."Id"
