USE LexiconDB

SELECT 
U.FirstName,
U.LastName,
U.Email,
U.UserName,
R.Name AS 'Role',
C.Id AS 'Course Id',
C.Name AS 'Course',
C.StartDate,
C.EndDate
FROM Courses AS C
INNER JOIN Users AS U ON U.CourseId = C.Id
INNER JOIN UserRoles AS UR ON U.Id = UR.UserId
INNER JOIN Roles AS R ON R.Id = UR.RoleId
WHERE C.Id = 9