-- Stored procedure để lấy tất cả các user
CREATE PROCEDURE GetAllUsers()
BEGIN
    SELECT * FROM Users;
END;