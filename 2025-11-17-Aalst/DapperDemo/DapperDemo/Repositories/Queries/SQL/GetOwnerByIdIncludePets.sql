select  o.OwnerId, o.FirstName, o.LastName, o.Email,
        p.PetId, p.Name, p.DateOfBirth, p.DateOfDeath
from DapperDemoAalst.Owners o
left join DapperDemoAalst.Pets p on p.OwnerId = o.OwnerId
where o.OwnerId = @OwnerId