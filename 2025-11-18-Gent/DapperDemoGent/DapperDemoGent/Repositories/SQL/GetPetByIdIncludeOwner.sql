SELECT p.PetId, p.Name, p.DateOfBirth, p.DateOfDeath,
     o.OwnerId, o.FirstName, o.LastName, o.Email
FROM dappergent2.Pets p
INNER JOIN dappergent2.Owners o ON p.OwnerId = o.OwnerId
WHERE PetId = @PetId