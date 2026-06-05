UPDATE Astronauta
SET 
    Usuario = CAST(AstronautaID AS NVARCHAR) + 
              LEFT(Nombre, 1) + 
              LEFT(Apellido, 1) + 
              RIGHT(Apellido, 1),
    Contrasena = '*Alfa123'