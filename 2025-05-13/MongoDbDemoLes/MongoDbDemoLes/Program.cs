// See https://aka.ms/new-console-template for more information

using MongoDB.Driver;
using MongoDbDemoLes;

Console.WriteLine("Hello, World!");

// Connect
var client = new MongoClient("mongodb://localhost:27017");

var db = client.GetDatabase("pg2les");
if(db is null)
    throw new Exception("Database not found");

var coll = db.GetCollection<DemoModel>("voorbeeldles");
if(coll is null)
    throw new Exception("Collection not found");

// Create
var docToCreate = new DemoModel
{
    MijnVeldText = "Ik Ben tekst",
    MijnVeldNumber = 3.2,
    MijnVeldBool = false,
    MijnVeldLeeg = null,
    MijnVeldArrayInts = [2,5,7],
    MijnVeldObject = new DemoModelObjectProp
    {
        MijnObjectVeld = "Ik ben een object"
    }
};

coll.InsertOne(docToCreate);

// Read
var foundDoc = coll.Find(x => x.MijnVeldText == "Ik Ben tekst").FirstOrDefault();
Console.WriteLine(foundDoc.Id);

// Update
foundDoc.MijnVeldText = "Ik ben tekst gewijzigd";
coll.ReplaceOne(x => x.Id == foundDoc.Id, foundDoc);

coll.UpdateOne( f =>
    // welk document
    f.Id == foundDoc.Id,
    // welke operatie
    Builders<DemoModel>.Update.Set( d => d.MijnVeldText, "Tekst Updated 2, enkel veld"));

// Filter simple
var simpleFilter = Builders<DemoModel>.Filter.Eq(d =>
    d.MijnVeldText, "Tekst Updated 2, enkel veld");

var result= coll.Find(simpleFilter).ToList();

// Filter composed
var compositeFilter = Builders<DemoModel>.Filter.And(
    Builders<DemoModel>.Filter.Eq(d => d.MijnVeldBool, false),
    Builders<DemoModel>.Filter.Lt(d => d.MijnVeldNumber, 100)
);

var resultComposite= coll.Find(compositeFilter).ToList();


// Delete
coll.DeleteOne(x => x.Id == foundDoc.Id);
    
Console.WriteLine("Done");