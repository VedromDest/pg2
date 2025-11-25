// See https://aka.ms/new-console-template for more information

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDriverDemoGent;

Console.WriteLine("Hello, World!");

// Connect to MongoDB Server
var mongoClient = new MongoClient("mongodb://localhost:27017");

// Connect to MongoDB Database
const string databaseName = "pg2gent";
var dbExists = mongoClient.ListDatabaseNames().ToList().Contains(databaseName);
if(!dbExists)
    throw new Exception($"Database '{databaseName}' not found");
var database = mongoClient.GetDatabase(databaseName);
Console.WriteLine("Connected to database " + database.DatabaseNamespace);

// Obtain handle to collection
const string collectionName = "voorbeeldcollection";
var collectionExists = database.ListCollectionNames().ToList().Contains(collectionName);
if(!collectionExists)
    throw new Exception($"Collection '{collectionName}' not found");
var collection = database.GetCollection<GentModel>(collectionName);
Console.WriteLine("Obtained handle to collection " + collection.CollectionNamespace);

// Create
var toCreate = new GentModel
{
    MijnVeldText = "Tekst",
    MijnVeldNumber = 4.2,
    MijnVeldBool = true,
    MijnVeldLeeg = null,
    MijnVeldArrayInts = [1, 2, 3],
    MijnVeldObject = new DemoModelObjectProp
    {
        MijnObjectVeld = "Hallo"
    }
};

collection.InsertOne(toCreate);

// Read Single
var result = collection.Find(document => document.MijnVeldText == "Tekst").SingleOrDefault();
Console.WriteLine("Read Single result Id " + result.Id);

// Replace Document
result.MijnVeldText = "Veranderd";
collection.ReplaceOne(document => document.Id == result.Id, result);

// Update Document
result.MijnVeldText = "Blablefklklerzfjklzejklzfjk"; // Dit heeft dus geen effect
collection.UpdateOne(document => document.Id == result.Id, 
    Builders<GentModel>.Update.Set(document => document.MijnVeldBool, false));

// Simple Filter
var simpleFilter = Builders<GentModel>.Filter.Eq(document => document.MijnVeldBool, false);
var simpleFilterResult = collection.Find(simpleFilter).ToList();
Console.WriteLine($"{nameof(simpleFilterResult)} {simpleFilterResult[0].Id}");

// Composed Filter
var composedFilter = Builders<GentModel>.Filter.And(
    simpleFilter, 
    Builders<GentModel>.Filter.Eq(document => document.MijnVeldText, "Veranderd"));
var composedFilterResult = collection.Find(composedFilter).ToList();
Console.WriteLine($"{nameof(composedFilterResult)} {composedFilterResult[0].Id}");

// Complex Composed Filter
var complexComposedFilter = Builders<GentModel>.Filter.And(
    simpleFilter, // waar
    Builders<GentModel>.Filter.Eq(document => document.MijnVeldText, "Veranderd"), // waar
    Builders<GentModel>.Filter.Or( // een van deze moet waar zijn
        Builders<GentModel>.Filter.Eq(document => document.MijnVeldArrayInts[1], 1), // niet waar
        Builders<GentModel>.Filter.Lt(document => document.MijnVeldNumber, 10) // waar
        )
    );
var complexComposedFilterResult = collection.Find(complexComposedFilter).ToList();
Console.WriteLine($"{nameof(complexComposedFilterResult)} {complexComposedFilterResult[0].Id}");

// Delete Document
collection.DeleteOne(document => document.Id == result.Id);


