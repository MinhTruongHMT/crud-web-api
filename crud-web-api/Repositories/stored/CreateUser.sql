-- Stored procedure để thêm user mới
CREATE PROCEDURE CreateUser(IN userTitle VARCHAR(255), 
                             IN userFirstName VARCHAR(255), 
                             IN userLastName VARCHAR(255), 
                             IN userEmail VARCHAR(255), 
                             IN userRole VARCHAR(255), 
                             IN userPasswordHash VARCHAR(255))
BEGIN
    INSERT INTO Users (Title, FirstName, LastName, Email, Role, PasswordHash)
    VALUES (userTitle, userFirstName, userLastName, userEmail, userRole, userPasswordHash);
END;