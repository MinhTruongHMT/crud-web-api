-- Stored procedure để lấy user theo id
CREATE PROCEDURE GetUserById(IN userId INT)
BEGIN
    SELECT * FROM Users WHERE Id = userId;
END;