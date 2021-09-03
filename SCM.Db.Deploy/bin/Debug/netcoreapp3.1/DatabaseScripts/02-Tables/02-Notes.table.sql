
CREATE TABLE Notes
(
	NoteId INT Identity(1,1) primary key,
	Title VARCHAR(50),
	Description VARCHAR(max),
	CreateByUserId INT not null,
	UpdateByUserId INT not null,
	CreatedDate DateTime Default(getdate()),
	UpdatedDate CreatedDate Default(getdate())
);