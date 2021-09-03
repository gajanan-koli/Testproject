
CREATE TABLE ApplicationUser
(
	Id INT Identity(1,1) primary key,
	FirstName VARCHAR(50),
	UserName VARCHAR(100),
	Email VARCHAR(100),
	CreateByUserId INT,
	UpdateByUserId INT,
	CreatedDate DateTime Default(getdate()),
	UpdatedDate CreatedDate Default(getdate())
);

