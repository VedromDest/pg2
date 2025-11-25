using MongoDB.Bson;

namespace MongoDriverDemoGent;

public class GentModel
{
    public ObjectId Id { get; set; }
    public required string MijnVeldText { get; set; }
    public required double MijnVeldNumber { get; set; }
    public required bool MijnVeldBool { get; set; }
    public string? MijnVeldLeeg { get; set; }
    public required int[] MijnVeldArrayInts { get; set; }
    public required DemoModelObjectProp MijnVeldObject { get; set; }
}

public class DemoModelObjectProp
{
    public required string MijnObjectVeld { get; set; }
}