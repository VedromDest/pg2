// See https://aka.ms/new-console-template for more information

using MongoDB.Driver;
using MongoDemo;

Console.WriteLine("Hello, World!");
var dbClient = new MongoClient("mongodb://localhost:27017");

// Referentie naar bestaande database maken.
// We controleren dit om er voor te zorgen dat er niet impliciet database gemaakt worden.
const string databaseName = "pg2aalst"; 
if (!dbClient.ListDatabaseNames().ToList().Contains(databaseName))
    throw new Exception($"Database {databaseName} bestaat niet");
IMongoDatabase db = dbClient.GetDatabase(databaseName);

// Referentie naar bestaande collection maken
const string collectionName = "testcollection"; 
if (!db.ListCollectionNames().ToList().Contains(collectionName))
    throw new Exception($"Collection {collectionName} bestaat niet");
var myCollection = db.GetCollection<DemoModel>(collectionName);

// INSERT
var toCreate = new DemoModel
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
myCollection.InsertOne(toCreate);

// READ
var readDocument = myCollection.Find(d => d.MijnVeldText == "Tekst").Single();

// REPLACE
Console.WriteLine(readDocument.MijnVeldText);
readDocument.MijnVeldText = "Tekst gewijzigd";
myCollection.ReplaceOne(d => d.Id == readDocument.Id, readDocument);

// UPDATE
readDocument.MijnVeldLeeg = "er zit nu iets in"; // Dit heeft geen effect
myCollection.UpdateOne(d => d.Id == readDocument.Id, 
    Builders<DemoModel>.Update.Set(d => d.MijnVeldText, "Tekst gewijzigd door fijnmazige update"));

// Enkelvoudige filter
var simpleFilter = Builders<DemoModel>.Filter.Eq(d =>
    d.MijnVeldText, "Tekst gewijzigd door fijnmazige update");

var gevondenDocumentEnkelvoudigeFilter= myCollection.Find(simpleFilter).ToList();
foreach (var demoModel in gevondenDocumentEnkelvoudigeFilter)
{
    Console.WriteLine($"Gevonden met enkelvoudige filter {demoModel.Id}");
}

// Dubbele filter
var dubbeleFilter = Builders<DemoModel>.Filter.And(
    simpleFilter, 
               Builders<DemoModel>.Filter.Eq(d => d.MijnVeldNumber, 4.2)
    );
var gevondenDocumentDubbeleFilter= myCollection.Find(dubbeleFilter).ToList();
foreach (var demoModel in gevondenDocumentDubbeleFilter)
{
    Console.WriteLine($"Gevonden met dubbele filter {demoModel.Id}");
}

// Geneste filter
var nestedFilter = Builders<DemoModel>.Filter.And(
    Builders<DemoModel>.Filter.Eq(d => d.MijnVeldText, "Tekst gewijzigd door fijnmazige update"),
    Builders<DemoModel>.Filter.Lt(d => d.MijnVeldNumber, 100),
    Builders<DemoModel>.Filter.Or(
        Builders<DemoModel>.Filter.Eq(d => d.MijnVeldArrayInts[1], 1),
        Builders<DemoModel>.Filter.Gt(d => d.MijnVeldNumber, 2)
    )
);

var resultNested= myCollection.Find(nestedFilter).ToList();
foreach (var demoModel in resultNested)
{
    Console.WriteLine($"Gevonden met nested filter {demoModel.Id}");
}

// DELETE
myCollection.DeleteOne(d => d.Id == readDocument.Id);