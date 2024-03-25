-- Stored procedure để lấy user theo email
CREATE PROCEDURE GetUserByEmail(IN userEmail VARCHAR(255))
BEGIN
    SELECT * FROM Users WHERE Email = userEmail;
END;