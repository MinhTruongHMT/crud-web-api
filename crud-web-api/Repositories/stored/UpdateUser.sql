-- Stored procedure để cập nhật thông tin user
CREATE PROCEDURE UpdateUser(IN userId INT,
                             IN userTitle VARCHAR(255), 
                             IN userFirstName VARCHAR(255), 
                             IN userLastName VARCHAR(255), 
                             IN userEmail VARCHAR(255), 
                             IN userRole VARCHAR(255), 
                             IN userPasswordHash VARCHAR(255))
BEGIN
    UPDATE Users 
    SET Title = userTitle,
        FirstName = userFirstName,
        LastName = userLastName, 
        Email = userEmail, 
        Role = userRole, 
        PasswordHash = userPasswordHash
    WHERE Id = userId;
END;
