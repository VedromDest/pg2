# Dapper Demo 2

- `QueryRepo` is een _singleton_ om als eenvoudige query cache te dienen.
- `QueryRepo` leest connectionstring via `IConfiguration`. 
  - _Options Pattern_ natuurlijk nog mooier.
- `DemoTypeRepo` heeft een implementatie om record na `insert` te _returnen_.
  - Deze implementatie is eigen aan MySQL.
- Api tests via `.http` file.
  - VS 2022 en Rider ondersteunen standaard.
  - VS Code extension nodig, bv [Rest Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) 