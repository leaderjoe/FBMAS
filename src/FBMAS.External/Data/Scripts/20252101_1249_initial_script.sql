CREATE TABLE Logs (
	Id serial primary key,
	Timestamp timestamp with time zone not null,
	Log text not null
);