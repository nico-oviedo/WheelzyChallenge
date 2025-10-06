USE Wheelzy;
GO

SELECT		c.[Year]			AS [Year],
			ma.Name				AS Make,
			mo.Name				AS Model,
			sm.Name				AS Submodel,
			zc.Code				AS ZipCode,
			b.Name				AS BuyerName,
			b.Amount			AS Quote,
			s.Name				AS [Status],
			sh.[Date]			AS StatusDate
		
FROM		Car c

INNER JOIN	Make ma
ON			ma.Id = c.MakeId

INNER JOIN	Model mo
ON			mo.Id = c.ModelId

INNER JOIN	Submodel sm
ON			sm.Id = c.SubmodelId

INNER JOIN	ZipCode zc
ON			zc.Id = c.ZipCodeId

LEFT JOIN	CarQuote cq
ON			cq.CarId = c.Id
AND			cq.IsCurrent = 1

LEFT JOIN	Buyer b
ON			b.Id = cq.BuyerId

LEFT JOIN	[Status] s
ON			s.Id = cq.StatusId

LEFT JOIN	StatusHistory sh
ON			sh.CarQuoteId = cq.Id
AND			sh.StatusId = cq.StatusId


