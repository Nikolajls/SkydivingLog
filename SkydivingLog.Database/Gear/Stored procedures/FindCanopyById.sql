CREATE PROCEDURE [Gear].[FindCanopyById]
    @Id int = 0
AS
    SELECT 
    canopy.Id,
    canopy.SquareFoot,
    canopy.SerialNumber,
    canopy.ManufacturedDate,
    model.Name AS [ModelName],
    model.Cells,
    model.Elliptical,
    model.CanopyLevel AS [Level],
    model.CanopyType AS [Type],
    manu.Name AS [ManufacturerName]
    FROM Gear.Canopies canopy
    INNER JOIN Gear.CanopyModels model ON model.Id = canopy.CanopyModelId
    INNER JOIN Gear.Manufacturers manu ON manu.Id = model.ManufacturerId
    WHERE  canopy.Id = @Id
