USE Wheelzy;
GO

-- STATUS TABLE INITIAL INSERT
SET IDENTITY_INSERT [Status] ON;
INSERT INTO [Status](Id, [Name],[HasMandatoryDate])
VALUES
	(1, 'Pending Acceptance', 0),
	(2, 'Accepted', 0),
	(3, 'Picked Up', 1),
	(4, 'Completed', 0);
SET IDENTITY_INSERT [Status] OFF;


-- MAKE TABLE TEST DATA
SET IDENTITY_INSERT Make ON;
INSERT INTO Make (Id, Name) 
VALUES 
	(1, 'Toyota'),
	(2, 'Honda'),
	(3, 'Ford');
SET IDENTITY_INSERT Make OFF;


-- MODEL TABLE TEST DATA
SET IDENTITY_INSERT Model ON;
INSERT INTO Model (Id, MakeId, Name) 
VALUES 
	(1, 1, 'Corolla'),
	(2, 1, 'Camry'),
	(3, 2, 'Civic'),
	(4, 2, 'Accord'),
	(5, 3, 'Focus'),
	(6, 3, 'Mustang');
SET IDENTITY_INSERT Model OFF;


-- SUBMODEL TABLE TEST DATA
SET IDENTITY_INSERT SubModel ON;
INSERT INTO SubModel (Id, ModelId, Name) 
VALUES 
	(1, 1, 'LE'),
	(2, 1, 'SE'),
	(3, 2, 'XSE'),
	(4, 3, 'LX'),
	(5, 4, 'Sport'),
	(6, 5, 'Titanium'),
	(7, 6, 'GT');
SET IDENTITY_INSERT SubModel OFF;


-- CUSTOMER TABLE TEST DATA
SET IDENTITY_INSERT Customer ON;
INSERT INTO Customer (Id, Name) 
VALUES 
	(1, 'John Doe'),
	(2, 'Jane Smith'),
	(3, 'Carlos Perez');
SET IDENTITY_INSERT Customer OFF;


-- ZIP CODE TABLE TEST DATA
SET IDENTITY_INSERT ZipCode ON;
INSERT INTO ZipCode (Id, Code) 
VALUES 
	(1, '10001'), -- New York
	(2, '90001'), -- Los Angeles
	(3, '60601'), -- Chicago
	(4, '33101'); -- Miami
SET IDENTITY_INSERT ZipCode OFF;


-- CARS TABLE TEST DATA
SET IDENTITY_INSERT Car ON;
INSERT INTO Car (Id, CustomerId, [Year], MakeId, ModelId, SubmodelId, ZipCodeId)
VALUES 
	(1, 1, '2018', 1, 1, 1, 1), -- Toyota Corolla LE in NY
	(2, 2, '2020', 2, 3, 4, 2), -- Honda Civic LX in LA
	(3, 3, '2019', 3, 6, 7, 3); -- Ford Mustang GT in Chicago
SET IDENTITY_INSERT Car OFF;


-- BUYER TABLE TEST DATA
SET IDENTITY_INSERT Buyer ON;
INSERT INTO Buyer (Id, Name, Amount) 
VALUES 
	(1, 'Fernando Alonso', 500.00),
	(2, 'Chris Rodriguez', 600.00),
	(3, 'Adam Sandler', 550.00);
SET IDENTITY_INSERT Buyer OFF;


-- ZIPCODE TO BUYER TABLE TEST DATA
INSERT INTO ZipCode_Buyer (ZipCodeId, BuyerId) 
VALUES 
	(1, 1), -- Fernando Alonso covers NY
	(2, 1), -- Fernando Alonso covers LA
	(3, 2), -- Chris Rodriguez covers Chicago
	(4, 2), -- Chris Rodriguez covers Miami
	(1, 3), -- Adam Sandler covers NY
	(2, 3), -- Adam Sandler covers LA
	(3, 3); -- Adam Sandler covers Chicago


-- CAR QUOTES TABLE TEST DATA
SET IDENTITY_INSERT CarQuote ON;
INSERT INTO CarQuote (Id, CarId, BuyerId, StatusId, IsCurrent)
VALUES 
	(1, 1, 1, 1, 1),
	(2, 2, 2, 2, 1),
	(3, 2, 3, 1, 0),
	(4, 3, 3, 3, 1);
SET IDENTITY_INSERT CarQuote OFF;


-- STATUS HISTORY TABLE TEST DATA
INSERT INTO StatusHistory (CarQuoteId, StatusId, [Date], ChangedBy)
VALUES 
	(1, 1, GETDATE()-5, 'System'),
	(1, 2, GETDATE()-2, 'Admin'),
	(2, 2, GETDATE()-3, 'System'),
	(2, 3, GETDATE()-1, 'Driver'),
	(3, 1, GETDATE()-4, 'System'),
	(4, 3, GETDATE()-1, 'Admin');
