namespace EFCoreCodeFirst;

public class OptionalToSql
{
    public int Id { get; set; }
    
    public string GewoneString { get; set; }
    public string? OptioneleString { get; set; }
    public required string RequiredString { get; set; }
    public string GewoneStringNullForgiving { get; set; } = null!;
    public int GewoneInt { get; set; }
    public int? NullabelInt { get; set; }
}

/*
create table efcoreaalst.OptionalToSqls
   (
       Id                        int auto_increment primary key,
       GewoneString              longtext not null,
       OptioneleString           longtext null,
       RequiredString            longtext not null,
       GewoneStringNullForgiving longtext not null
   );
   
   
*/