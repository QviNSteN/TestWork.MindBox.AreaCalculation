SELECT
P."Name",
C."Name"

FROM "Products" as P
LEFT JOIN "Product2Category" as P2C on  P."Id" = P2C."ProductId"
LEFT JOIN "Category" as C on  P2C."CategoryId" = C."Id"